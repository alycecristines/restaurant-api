using Restaurant.Core.Common;

namespace Restaurant.Core.QueryObjects
{
    public class CompanyQueryFilter : QueryFilter
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
