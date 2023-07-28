using FlightsApi.Models;
using MongoDB.Driver;
using FlightsApi.Model;

namespace FlightsApi.Services
{
    public class FlightService : IFlightService
    {
        private readonly IMongoCollection<Flight> _flights;

        public FlightService(IFlightStoreDatabaseSettings setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _flights = database.GetCollection<Flight>(setting.FlightCollectionName);
        }


        public Flight Create(Flight flight)
        {
            _flights.InsertOne(flight);
            return flight;
        }

        public List<Flight> Get()
        {
            return _flights.Find(flight => true).ToList();
        }

        public Flight Get(string id)
        {
            return _flights.Find(flight => flight.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _flights.DeleteOne(flight => flight.Id == id);
        }

        public void Update(string id, Flight flight)
        {
            _flights.ReplaceOne(flight => flight.Id == id, flight);
        }
    }
}
