using Restaurant.Core.QueryObjects.Base;

namespace Restaurant.Core.QueryObjects
{
    public class CompanyQuery : Query
    {
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
