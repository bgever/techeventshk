using System.Threading.Tasks;
using Tehk.Sourcers.Eventbrite.Svc.Dtos;

namespace Tehk.Sourcers.Eventbrite.Svc.Services
{
    public interface IEventbriteApiClient
    {
        Task<EventsResponse> GetOrganizationEvents(string organizationId);
    }
}