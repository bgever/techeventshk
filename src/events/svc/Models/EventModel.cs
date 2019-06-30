using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tehk.Events.Svc.Models
{
    public class EventModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string OrgSlug { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}