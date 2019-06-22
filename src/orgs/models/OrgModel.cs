using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tehk.Orgs.Models
{
    /// <summary>
    /// Event organizations.
    /// </summary>
    public class OrgModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Slug { get; set; }

        public string Name { get; set; }

        public string WebsiteUrl { get; set; }

        public string Description { get; set; }

        public string LocationCode { get; set; }

        /// <summary>
        /// Collection of source definitions where events come from.
        /// </summary>
        /// <value></value>
        public ICollection<SourcerModel> Sourcers { get; set; }
    }
}
