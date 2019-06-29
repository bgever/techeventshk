using System.Collections.Generic;

namespace Tehk.Sourcers.Eventbrite.Svc.Dtos
{
    public class EventsResponse
    {
        public Pagination Pagination { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}