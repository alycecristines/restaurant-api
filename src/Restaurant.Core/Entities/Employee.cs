using System;

namespace Restaurant.Core.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Deleted => DeletedAt.HasValue;
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public Employee()
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
