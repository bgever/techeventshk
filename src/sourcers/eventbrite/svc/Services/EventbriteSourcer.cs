using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehk.Sourcers.Eventbrite.Svc.Dtos;

namespace Tehk.Sourcers.Eventbrite.Svc.Services
{
    public class EventbriteSourcer : IEventbriteSourcer
    {
        public EventbriteSourcer(IEventbriteApiClient eventbriteApi)
        {
            EventbriteApi = eventbriteApi;
        }

        private IEventbriteApiClient EventbriteApi { get; }

        public async Task<IEnumerable<Event>> ListEvents()
        {
            // https://www.eventbrite.com/platform/api#/reference/event/update/list-events-by-organization

            string organizationId = "14955702180"; //open-source-hong-kong

            return (await EventbriteApi.GetOrganizationEvents(organizationId))?.Events;
        }
    }
}