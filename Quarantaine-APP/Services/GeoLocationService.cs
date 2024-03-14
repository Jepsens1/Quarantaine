using Quarantaine_APP.Interfaces;

namespace Quarantaine_APP.Services
{
    public class GeoLocationService : ILocation
    {
        private bool _isCheckingLocation;
        public double CalculateDistance()
        {
            //Test data
            Location boston = new Location(42.358056, -71.063611);
            Location sanFrancisco = new Location(37.783333, -122.416667);
            return Location.CalculateDistance(boston, sanFrancisco, DistanceUnits.Kilometers);
        }

        public async Task<string> GetCachedLocation()
        {
            try
            {
                Location? location = await Geolocation.Default.GetLastKnownLocationAsync().ConfigureAwait(false);
                if (location != null)
                {
                    return $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                }
            }
            catch (FeatureNotSupportedException)
            {
                return "Feature is not supported on this device";
            }
            catch (FeatureNotEnabledException)
            {
                return "Feature not enabled on this device";
            }
            catch (PermissionException)
            {
                return "You need to allow location permissions";
            }
            catch (Exception)
            {
                return "Unable to get location";
            }
            return "None";
        }

        public async Task GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));

                Location? location = await Geolocation.Default.GetLocationAsync(request).ConfigureAwait(false);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    Vibration.Default.Vibrate(TimeSpan.FromSeconds(4));
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _isCheckingLocation = false;
            }
        }
    }
}
