using AutoMapper;
using Tehk.Events.Dtos;
using Tehk.Events.Svc.Models;

namespace Tehk.Orgs.Svc.Mappings
{
    public class EventMapping : Profile
    {
        public EventMapping()
        {
            CreateMap<EventModel, Event>();
        }
    }
}