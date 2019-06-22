using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Tehk.Orgs.Models;

namespace Tehk.Orgs.Svc.Services
{
    public class OrgService : IOrgService
    {
        public OrgService(IMongoCollection<OrgModel> collection, ILogger<OrgService> logger)
        {
            Collection = collection;
            Logger = logger;
        }

        private IMongoCollection<OrgModel> Collection { get; }
        private ILogger<OrgService> Logger { get; }

        public async Task<IEnumerable<OrgModel>> List()
        {
            return await Collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<OrgModel> Find(string slug)
        {
            return await Collection.Find(Builders<OrgModel>.Filter.Eq(x => x.Slug, slug)).FirstOrDefaultAsync();
        }

        public async Task<OrgModel> Update(string slug, OrgModel org)
        {
            return await Collection.FindOneAndReplaceAsync(Builders<OrgModel>.Filter.Eq(x => x.Slug, slug), org);
        }

        public async Task<OrgModel> Delete(string slug)
        {
            return await Collection.FindOneAndDeleteAsync(Builders<OrgModel>.Filter.Eq(x => x.Slug, slug));
        }
    }
}