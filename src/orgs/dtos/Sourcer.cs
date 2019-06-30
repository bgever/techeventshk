namespace Tehk.Orgs.Dtos
{
    /// <summary>
    /// The method used for sourcing new events.
    /// </summary>
    public class Sourcer
    {
        /// <summary>
        /// Identifier of the sourcer.
        /// </summary>
        /// <value>Lower-case reference code.</value>
        public string Code { get; set; }

        /// <summary>
        /// URI used to configure the sourcer.
        /// </summary>
        /// <value>Uniform resource identifer.</value>
        public string Uri { get; set; }
    }
}