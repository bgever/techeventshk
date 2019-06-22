using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tehk.Orgs.Models;
using Tehk.Orgs.RestApi;
using Tehk.Orgs.Svc.Services;

namespace Tehk.Orgs.Svc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgController : ControllerBase
    {
        public OrgController(IOrgService orgs, IMapper mapper)
        {
            Orgs = orgs;
            Mapper = mapper;
        }

        public IOrgService Orgs { get; }
        public IMapper Mapper { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Org>>> Get()
        {
            return Ok(Mapper.Map<IEnumerable<OrgModel>, IEnumerable<Org>>(await Orgs.List()));
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<string>> Get(string slug)
        {
            var org = await Orgs.Find(slug);
            if (org == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<OrgModel, Org>(org));
        }

        [HttpPost]
        public void Post([FromBody] Org org)
        {
        }

        [HttpPut("{slug}")]
        public void Put(string slug, [FromBody] Org org)
        {
        }

        [HttpDelete("{slug}")]
        public void Delete(int slug)
        {
        }
    }
}
