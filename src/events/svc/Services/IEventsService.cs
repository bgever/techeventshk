using System.Collections.Generic;
using System.Threading.Tasks;
using Tehk.Events.Svc.Models;

namespace Tehk.Events.Svc.Services
{
    public interface IEventsService
    {
        Task<IEnumerable<EventModel>> GetEvents();

        Task<IEnumerable<EventModel>> GetEventsByOrg(string orgSlug);
    }
}