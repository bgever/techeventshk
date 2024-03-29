namespace Tehk.Sourcers.Eventbrite.Svc.Dtos
{
    public class Pagination
    {
        public int ObjectCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public string Continuation { get; set; }

        public bool HasMoreItems { get; set; }
    }
}