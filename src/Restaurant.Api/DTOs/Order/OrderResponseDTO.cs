using System;
using System.Collections.Generic;
using Restaurant.Api.DTOs.Base;
using Restaurant.Api.DTOs.Employee;

namespace Restaurant.Api.DTOs.Order
{
    public class OrderResponseDTO : ResponseDTO
    {
        public DateTime CreatedAt { get; set; }
        public EmployeeResponseDTO Employee { get; set; }
        public IEnumerable<OrderItemResponseDTO> Items { get; set; }
    }
}
