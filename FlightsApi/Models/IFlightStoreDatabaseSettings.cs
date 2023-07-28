namespace FlightsApi.Models
{
    public interface IFlightStoreDatabaseSettings
    {
        string FlightCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
