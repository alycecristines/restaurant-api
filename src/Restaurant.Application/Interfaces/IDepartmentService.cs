using System;
using System.Collections.Generic;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;
using Restaurant.Application.QueryParams;

namespace Restaurant.Application.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentResponseDTO Insert(DepartmentRequestDTO dto);
        IEnumerable<DepartmentResponseDTO> GetAll(DepartmentQueryParams queryParams);
        DepartmentResponseDTO Get(Guid id);
        void Delete(Guid id);
    }
}
