namespace Restaurant.Application.QueryParams
{
    public class CompanyQueryParams
    {
        public bool IncludeInactivated { get; set; }
        public bool IncludeDeleted { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
