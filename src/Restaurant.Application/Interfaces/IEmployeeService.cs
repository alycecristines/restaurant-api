using System;
using System.Collections.Generic;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;
using Restaurant.Application.QueryParams;

namespace Restaurant.Application.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeResponseDTO Insert(EmployeePostPutDTO dto);
        IEnumerable<EmployeeResponseDTO> GetAll(EmployeeQueryParams queryParams);
        EmployeeResponseDTO Get(Guid id);
        EmployeeResponseDTO Update(Guid id, EmployeePostPutDTO dto);
        void Delete(Guid id);
    }
}
