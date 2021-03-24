using System;
using Restaurant.Core.Common;

namespace Restaurant.Core.Entities
{
    public class Employee : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Guid DepartmentId { get; private set; }
        public Department Department { get; private set; }
    }
}
