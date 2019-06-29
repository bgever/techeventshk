using System.Collections.Generic;
using System.Threading.Tasks;
using Tehk.Sourcers.Meetup.Svc.Models;

namespace Tehk.Sourcers.Meetup.Svc.Services
{
    public interface IMeetupApiClient
    {
        Task<IEnumerable<MeetupEventModel>> GetEvents(string urlName, EventsScroll scroll = EventsScroll.Undefined);
    }
}