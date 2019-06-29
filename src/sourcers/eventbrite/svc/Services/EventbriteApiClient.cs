using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using Tehk.Sourcers.Eventbrite.Svc.Dtos;

namespace Tehk.Sourcers.Eventbrite.Svc.Services
{
    public class EventbriteApiClient : IEventbriteApiClient
    {
        public EventbriteApiClient(HttpClient httpClient, ILogger<EventbriteApiClient> logger)
        {
            HttpClient = httpClient;
            Logger = logger;
        }

        private HttpClient HttpClient { get; }
        private ILogger<EventbriteApiClient> Logger;

        public async Task<EventsResponse> GetOrganizationEvents(string organizationId)
        {
            EventsResponse Default() => null;

            if (string.IsNullOrWhiteSpace(organizationId))
            {
                Logger.LogError($"Null or whitespace urlname, aborting API call.");
                return Default();
            }

            var response = await HttpClient.GetAsync($"organizers/{HttpUtility.UrlEncode(organizationId)}/events/");
            if (!response.IsSuccessStatusCode)
            {
                Logger.LogError($"Unexpected Eventbrite API response; status code {response.StatusCode}.");
                return Default();
            }
            try
            {
                return await response.Content.ReadAsAsync<EventsResponse>();
            }
            catch (Exception e)
            {
                Logger.LogError("Unable to deserialize API response.", e);
                return Default();
            }
        }
    }
}