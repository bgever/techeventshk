using System.Collections.Generic;
using System.Threading.Tasks;
using Tehk.Sourcers.Eventbrite.Svc.Dtos;

namespace Tehk.Sourcers.Eventbrite.Svc.Services
{
    public interface IEventbriteSourcer
    {
        Task<IEnumerable<Event>> ListEvents();
    }
}