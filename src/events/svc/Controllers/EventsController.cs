using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tehk.Events.Dtos;
using Tehk.Events.Svc.Models;
using Tehk.Events.Svc.Services;

namespace Tehk.Events.Svc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        public EventsController(IEventsService events, IMapper mapper)
        {
            Events = events;
            Mapper = mapper;
        }

        private IEventsService Events { get; }
        private IMapper Mapper { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            IEnumerable<EventModel> events = await Events.GetEvents();

            return Ok(Mapper.Map<IEnumerable<EventModel>, IEnumerable<Event>>(events));
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
