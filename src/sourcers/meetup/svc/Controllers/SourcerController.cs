using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tehk.Sourcers.Meetup.Svc.Models;
using Tehk.Sourcers.Meetup.Svc.Services;

namespace Tehk.Sourcers.Meetup.Svc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourcerController : ControllerBase
    {
        public SourcerController(IMeetupSourcer sourcer)
        {
            Sourcer = sourcer;
        }

        public IMeetupSourcer Sourcer { get; }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetupEventModel>>> Get()
        {
            return Ok(await Sourcer.ListEvents());
        }
    }
}
