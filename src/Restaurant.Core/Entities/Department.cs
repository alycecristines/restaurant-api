using System;
using System.Collections.Generic;

namespace Restaurant.Core.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Deleted => DeletedAt.HasValue;
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public Department()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(DateTime updatedAt)
        {
            UpdatedAt = updatedAt;
        }

        public void Delete(DateTime deletedAt)
        {
            DeletedAt = deletedAt;
        }
    }
}
