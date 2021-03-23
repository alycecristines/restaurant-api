using System;
using System.Collections.Generic;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;
using Restaurant.Application.QueryParams;

namespace Restaurant.Application.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeResponseDTO Insert(EmployeePostDTO dto);
        IEnumerable<EmployeeResponseDTO> GetAll(EmployeeQueryParams queryParams);
        EmployeeResponseDTO Get(Guid id);
        void Delete(Guid id);
    }
}
