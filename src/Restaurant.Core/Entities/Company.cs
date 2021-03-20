using System;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Core.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CorporateName { get; set; }
        public string BusinessName { get; set; }
        public string RegistrationNumber { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }

        public Company()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void Delete(DateTime deletedAt)
        {
            DeletedAt = deletedAt;
        }
    }
}
