using AutoMapper;
using Tehk.Orgs.Models;
using Tehk.Orgs.Dtos;

namespace Tehk.Orgs.Svc.Mappings
{
    public class OrgMapping : Profile
    {
        public OrgMapping()
        {
            CreateMap<OrgModel, Org>();
        }
    }
}