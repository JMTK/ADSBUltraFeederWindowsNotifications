using ADSBNotification;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

Dictionary<string, DateTime> alreadyNotified = new Dictionary<string, DateTime>();
HttpClient httpClient = new HttpClient();
string host = Environment.GetEnvironmentVariable("ADSBNotifier_UltraFeederHost");
string url = $"http://{host}/data/aircraft.json";
string logoPath = Path.GetTempFileName();
string logoUrl = $"http://{host}/images/tar1090-favicon.png";
if (!string.IsNullOrEmpty(logoUrl))
{
    byte[] thumbnailBytes = await httpClient.GetByteArrayAsync(logoUrl);
    await File.WriteAllBytesAsync(logoPath, thumbnailBytes);
}
while (true)
{
    try
    {
        Console.WriteLine("Checking for flights...");
        HttpResponseMessage response = await httpClient.GetAsync(url);
        var aircraftResponse = await response.Content.ReadFromJsonAsync<AircraftResponse>(new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });

        Aircraft flightFlyingOver = aircraftResponse.Aircraft.FirstOrDefault(g => true);
        if (flightFlyingOver != null)
        {
            string flightNo = flightFlyingOver.Flight ?? flightFlyingOver.R;
            alreadyNotified.Add(flightNo, DateTime.Now);
            string imageUrl = $"https://api.planespotters.net/pub/photos/hex/{flightFlyingOver.Hex}?reg={flightFlyingOver.R}&icaoType={flightFlyingOver.T}";
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(imageUrl);
            PhotoResponse photoResponse = await HttpContentJsonExtensions.ReadFromJsonAsync<PhotoResponse>(httpResponseMessage.Content);
            PhotoResponse responseImage = photoResponse;
            string message = $"Flight {flightNo.Trim()} is now flying over";
            Console.WriteLine(message);
            string imagePath = Path.GetTempFileName();
            if (responseImage?.photos != null && responseImage.photos.Count > 0)
            {
                Photo photo = Enumerable.FirstOrDefault<Photo>(responseImage.photos);
                if (photo != null)
                {
                    message = $"{message} {photo.photographer}";
                    if (!string.IsNullOrEmpty(photo.link))
                        message = $"{message} ({photo.link})";
                    if (!string.IsNullOrEmpty(photo.thumbnail?.src))
                    {
                        byte[] thumbnailBytes = await httpClient.GetByteArrayAsync(photo.thumbnail_large.src);
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
        foreach (KeyValuePair<string, DateTime> keyValuePair in alreadyNotified)
        {
            KeyValuePair<string, DateTime> val = keyValuePair;
            if ((DateTime.Now - val.Value).TotalSeconds > 600.0)
                alreadyNotified.Remove(val.Key);
            val = new KeyValuePair<string, DateTime>();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
    await Task.Delay(10000);
}
