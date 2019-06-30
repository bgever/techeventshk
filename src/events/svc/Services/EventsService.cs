using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Tehk.Events.Svc.Models;

namespace Tehk.Events.Svc.Services
{
    public class EventsService : IEventsService
    {
        public EventsService(IMongoCollection<EventModel> collection, ILogger<EventsService> logger)
        {
            Collection = collection;
            Logger = logger;
        }

        private IMongoCollection<EventModel> Collection { get; }
        private ILogger<EventsService> Logger { get; }

        public async Task<IEnumerable<EventModel>> GetEvents()
        {
            try
            {
                return await Collection.Find(_ => true).ToListAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Cannot retrieve events.");
                return await Task.FromResult(new List<EventModel>(0));
            }
        }

        public async Task<IEnumerable<EventModel>> GetEventsByOrg(string orgSlug)
        {
            try
            {
                return await Collection.Find(Builders<EventModel>.Filter.Eq(x => x.OrgSlug, orgSlug)).ToListAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Cannot retrieve events by org.");
                return await Task.FromResult(new List<EventModel>(0));
            }
        }
    }
}