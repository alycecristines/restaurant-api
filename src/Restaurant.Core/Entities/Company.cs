using System;
using Restaurant.Core.ValueObjects;

namespace Restaurant.Core.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string CorporateName { get; set; }
        public string BusinessName { get; set; }
        public string RegistrationNumber { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
    }
}
