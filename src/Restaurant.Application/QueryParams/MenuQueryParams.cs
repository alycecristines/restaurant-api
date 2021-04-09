namespace Restaurant.Application.QueryParams
{
    public class MenuQueryParams
    {
        public bool IncludeInactivated { get; set; }
        public bool IncludeDeleted { get; set; }
        public string Description { get; set; }
    }
}
