using System;
using System.Collections.Generic;
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
    public class OrgsController : ControllerBase
    {
        public OrgsController(IEventsService events, IMapper mapper)
        {
            Events = events;
            Mapper = mapper;
        }

        private IEventsService Events { get; }
        private IMapper Mapper { get; }

        // GET api/values
        [HttpGet("{orgSlug}/events")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents(string orgSlug)
        {
            IEnumerable<EventModel> events = await Events.GetEventsByOrg(orgSlug);

            return Ok(Mapper.Map<IEnumerable<EventModel>, IEnumerable<Event>>(events));
        }
    }
}
