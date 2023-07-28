namespace FlightsApi.Models
{
    public class FlightStoreDatabaseSettings :IFlightStoreDatabaseSettings
    {
        public string FlightCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;

    }
}
