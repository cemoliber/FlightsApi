using FlightsApi.Model;
using FlightsApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService flightService;

        public FlightsController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Flight>> Get()
        {
            return flightService.Get();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Flight> Get(string id)
        {
            var flight = flightService.Get(id);

            if(flight == null)
            {
                return NotFound($"The flight has {id} not found");
            }
            return flight;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<Flight> Post([FromBody] Flight flight)
        {
            flightService.Create(flight);

            return CreatedAtAction(nameof(Get), new {id = flight.Id},flight);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Flight flight)
        {
            var existingFlight = flightService.Get(id);

            if(existingFlight == null)
            {
                return NotFound($"The flight has Id = {id} not found");
            }
            flightService.Update(id, flight);

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var flight = flightService.Get(id);
            if(flight == null)
            {
                return NotFound($"The fligh has Id = {id} not found");
            }
            flightService.Remove(flight.Id);

            return Ok($"The flight has Id = {id} deleted");
        }
    }
}
