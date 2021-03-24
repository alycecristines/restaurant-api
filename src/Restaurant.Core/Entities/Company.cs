using System.Collections.Generic;
using Restaurant.Core.Common;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Core.Entities
{
    public class Company : Entity
    {
        public string CorporateName { get; private set; }
        public string BusinessName { get; private set; }
        public string RegistrationNumber { get; private set; }
        public Phone Phone { get; private set; }
        public Address Address { get; private set; }

        public IEnumerable<Department> Departments { get; private set; }
    }
}
