using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tehk.Sourcers.Meetup.Svc.Models;

namespace Tehk.Sourcers.Meetup.Svc.Services
{
    public class MeetupSourcer : IMeetupSourcer
    {
        public MeetupSourcer(IMeetupApiClient meetupApi)
        {
            MeetupApi = meetupApi;
        }

        private IMeetupApiClient MeetupApi { get; }

        public async Task<IEnumerable<MeetupEventModel>> ListEvents()
        {
            // https://www.meetup.com/meetup_api/docs/:urlname/events/#list

            string meetup = "HK-Microservices-Serverless-APIs-powered-by-KintoHub";

            return (await Task.WhenAll(
                MeetupApi.GetEvents(meetup, EventsScroll.NextUpcoming),
                MeetupApi.GetEvents(meetup, EventsScroll.RecentPast))
            ).SelectMany(x => x);
        }
    }
}