using ADSBNotification;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Net.Http.Json;
using System.Text.Json;

var alreadyNotified = new Dictionary<string, DateTime>();
var httpClient = new HttpClient();
var host = Environment.GetEnvironmentVariable("ADSBNotifier_UltraFeederHost");
var stationLatLngEnv = Environment.GetEnvironmentVariable("ADSBNotifier_StationLatLng");
var stationRadiusInKilometers = double.Parse(Environment.GetEnvironmentVariable("ADSBNotifier_RadiusInKilometers") ?? "5");
var stationLatLng = stationLatLngEnv?.Split(',').Select(double.Parse).Chunk(2).Select(chunk => (chunk[0], chunk[1])).FirstOrDefault() ?? await Geolocation.GetCurrentLocationLatLng();
var url = $"http://{host}/data/aircraft.json";
var logoPath = Path.GetTempFileName();
var logoUrl = $"http://{host}/images/tar1090-favicon.png";

if (!string.IsNullOrEmpty(logoUrl))
{
    var thumbnailBytes = await httpClient.GetByteArrayAsync(logoUrl);
    await File.WriteAllBytesAsync(logoPath, thumbnailBytes);
}

while (true)
{
    try
    {
        Console.WriteLine("Checking for flights...");
        var response = await httpClient.GetAsync(url);
        var aircraftResponse = await response.Content.ReadFromJsonAsync<AircraftResponse>(new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });

        var r_earth = 6378;
        var flightFlyingOver = aircraftResponse.Aircraft.FirstOrDefault(g =>
        {
            var minLatitude = stationLatLng.Item1 + (-1 * stationRadiusInKilometers / r_earth) * (180 / Math.PI);
            var maxLatitude = stationLatLng.Item1 + (stationRadiusInKilometers / r_earth) * (180 / Math.PI);
            var minLongitude = stationLatLng.Item2 + (-1 * stationRadiusInKilometers / r_earth) * (180 / Math.PI) / Math.Cos(stationLatLng.Item1 * Math.PI / 180);
            var maxLongitude = stationLatLng.Item2 + (stationRadiusInKilometers / r_earth) * (180 / Math.PI) / Math.Cos(stationLatLng.Item1 * Math.PI / 180);

            return minLatitude <= g.Lat && g.Lat <= maxLatitude &&
                   minLongitude <= g.Lon && g.Lon <= maxLongitude &&
                   !alreadyNotified.ContainsKey(g.Flight ?? g.R);
        });
        if (flightFlyingOver != null)
        {
            var flightNo = flightFlyingOver.Flight ?? flightFlyingOver.R;
            alreadyNotified.Add(flightNo, DateTime.Now);
            var imageUrl = $"https://api.planespotters.net/pub/photos/hex/{flightFlyingOver.Hex}?reg={flightFlyingOver.R}&icaoType={flightFlyingOver.T}";
            var httpResponseMessage = await httpClient.GetAsync(imageUrl);
            var responseImage = await HttpContentJsonExtensions.ReadFromJsonAsync<PhotoResponse>(httpResponseMessage.Content);
            var message = $"Flight {flightNo.Trim()} is now flying over";
            Console.WriteLine(message);
            var imagePath = Path.GetTempFileName();
            if (responseImage?.photos != null && responseImage.photos.Count > 0)
            {
                Photo photo = Enumerable.FirstOrDefault<Photo>(responseImage.photos);
                if (photo != null)
                {
                    message = $"{message}{Environment.NewLine}{photo.photographer}";
                    if (!string.IsNullOrEmpty(photo.thumbnail?.src))
                    {
                        var thumbnailBytes = await httpClient.GetByteArrayAsync(photo.thumbnail_large.src);
                        await File.WriteAllBytesAsync(imagePath, thumbnailBytes);
                    }
                }
            }
            message += $" {flightFlyingOver.Hex} at {flightFlyingOver.AltBaro} feet, {flightFlyingOver.Gs} knots, {flightFlyingOver.Track}° track.";

            new ToastContentBuilder().AddText(message)
                .SetToastScenario(ToastScenario.Default)
                .AddHeroImage(new Uri(imagePath))
                .SetProtocolActivation(new Uri($"http://{host}/?icao={flightFlyingOver.Hex}"))
                .Show();
        }
        foreach (var val in alreadyNotified)
        {
            if ((DateTime.Now - val.Value).TotalSeconds > 600.0)
                alreadyNotified.Remove(val.Key);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
    await Task.Delay(10000);
}
