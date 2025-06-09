using CrossPlatformLibrary.Geolocation;
using Guards;
using Microsoft.Practices.ServiceLocation;
using System.Net;
using Windows.Devices.Geolocation;

namespace ADSBNotification
{
    public class Geolocation()
    {
        public static async Task<(double, double)> GetCurrentLocationLatLng()
        {
            var status = await Geolocator.RequestAccessAsync();
            if (status == GeolocationAccessStatus.Allowed) {
                var geolocator = new Geolocator();
                geolocator.DesiredAccuracyInMeters = 50;
                geolocator.AllowFallbackToConsentlessPositions();
                var lkl = (await geolocator.GetGeopositionAsync()).Coordinate;
                
                if ((lkl.Longitude, lkl.Latitude) != (0, 0))
                {
                    return (lkl.Latitude, lkl.Longitude);
                }
            }

            return (0, 0);
        }
    }
}
