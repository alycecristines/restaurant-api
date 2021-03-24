using System;
using System.Collections.Generic;
using Restaurant.Core.Common;

namespace Restaurant.Core.Entities
{
    public class Department : Entity
    {
        public string Description { get; private set; }

        public Guid CompanyId { get; private set; }
        public Company Company { get; private set; }

        public IEnumerable<Employee> Employees { get; private set; }
    }
}
