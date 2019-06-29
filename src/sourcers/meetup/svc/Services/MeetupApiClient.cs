using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using Tehk.Sourcers.Meetup.Svc.Models;

namespace Tehk.Sourcers.Meetup.Svc.Services
{
    public class MeetupApiClient : IMeetupApiClient
    {
        public MeetupApiClient(HttpClient httpClient, ILogger<MeetupApiClient> logger)
        {
            HttpClient = httpClient;
            Logger = logger;
        }

        private HttpClient HttpClient { get; }
        private ILogger<MeetupApiClient> Logger;

        public async Task<IEnumerable<MeetupEventModel>> GetEvents(
            string urlName, EventsScroll scroll = EventsScroll.Undefined)
        {
            IEnumerable<MeetupEventModel> Default() => new List<MeetupEventModel>(0);

            if (string.IsNullOrWhiteSpace(urlName))
            {
                Logger.LogError($"Null or whitespace urlname, aborting API call.");
                return Default();
            }

            NameValueCollection BuildQueryString(NameValueCollection query)
            {
                var collection = HttpUtility.ParseQueryString(string.Empty);
                foreach (var key in query.Cast<string>().Where(key => !string.IsNullOrEmpty(query[key])))
                {
                    collection[key] = query[key];
                }
                return collection;
            }

            var queryString = BuildQueryString(new NameValueCollection {
                {"photo-host", "secure"},
                {"scroll", scroll.ToDescriptionString()},
                {"desc", "true"} // Hack; this param results in more returned events and in correct order.
            });
            var response = await HttpClient.GetAsync($"/{HttpUtility.UrlEncode(urlName)}/events?{queryString}");
            if (!response.IsSuccessStatusCode)
            {
                Logger.LogError($"Unexpected meetup API response; status code {response.StatusCode}.");
                return Default();
            }
            try
            {
                return await response.Content.ReadAsAsync<List<MeetupEventModel>>();
            }
            catch (Exception e)
            {
                Logger.LogError("Unable to deserialize API response.", e);
                return Default();
            }
        }
    }
}