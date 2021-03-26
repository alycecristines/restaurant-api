using System;
using System.Collections.Generic;
using Restaurant.Application.DTOs.Department;
using Restaurant.Application.QueryParams;

namespace Restaurant.Application.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentResponseDTO Insert(DepartmentPostDTO dto);
        IEnumerable<DepartmentResponseDTO> GetAll(DepartmentQueryParams queryParams);
        DepartmentResponseDTO Get(Guid id);
        DepartmentResponseDTO Update(Guid id, DepartmentPutDTO dto);
        void Delete(Guid id);
    }
}
