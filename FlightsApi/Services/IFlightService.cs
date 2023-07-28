using FlightsApi.Model;

namespace FlightsApi.Services
{
    public interface IFlightService
    {
        List<Flight> Get();
        Flight Get(string id);
        Flight Create(Flight flight);
        void Update(string id, Flight flight);
        void Remove(string id);
    }
}
