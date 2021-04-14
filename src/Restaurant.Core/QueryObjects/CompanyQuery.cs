using Restaurant.Core.Common;

namespace Restaurant.Core.QueryObjects
{
    public class CompanyQuery : Query
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
