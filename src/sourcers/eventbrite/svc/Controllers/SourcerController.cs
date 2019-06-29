using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tehk.Sourcers.Eventbrite.Svc.Dtos;
using Tehk.Sourcers.Eventbrite.Svc.Services;

namespace Tehk.Sourcers.Eventbrite.Svc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourcerController : ControllerBase
    {
        public SourcerController(IEventbriteSourcer sourcer)
        {
            Sourcer = sourcer;
        }

        public IEventbriteSourcer Sourcer { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return Ok(await Sourcer.ListEvents());
        }
    }
}
