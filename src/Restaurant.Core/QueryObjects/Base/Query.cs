namespace Restaurant.Core.QueryObjects.Base
{
    public class Query
    {
        public bool IncludeInactivated { get; set; }
        public bool IncludeDeleted { get; set; }
    }
}
