using System;
using System.Collections.Generic;

namespace Tehk.Orgs.RestApi
{
    /// <summary>
    /// Event organizations.
    /// </summary>
    public class Org
    {
        public string Slug { get; set; }

        public string Name { get; set; }

        public string WebsiteUrl { get; set; }

        public string Description { get; set; } 

        public string LocationCode { get; set; }

        /// <summary>
        /// Collection of source definitions where events come from.
        /// </summary>
        /// <value></value>
        public ICollection<Sourcer> Sourcers { get; set; }
    }
}
