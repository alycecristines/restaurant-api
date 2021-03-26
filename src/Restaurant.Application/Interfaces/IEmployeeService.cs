using System;
using System.Collections.Generic;
using Restaurant.Application.DTOs.Employee;
using Restaurant.Application.QueryParams;

namespace Restaurant.Application.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeResponseDTO Insert(EmployeePostDTO dto);
        IEnumerable<EmployeeResponseDTO> GetAll(EmployeeQueryParams queryParams);
        EmployeeResponseDTO Get(Guid id);
        EmployeeResponseDTO Update(Guid id, EmployeePutDTO dto);
        void Delete(Guid id);
    }
}
