namespace Quarantaine_APP.Interfaces
{
    public interface ILocation
    {
        Task<string> GetCachedLocation();

        Task GetCurrentLocation();

        double CalculateDistance();

    }
}
