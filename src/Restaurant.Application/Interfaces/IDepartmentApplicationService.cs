using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Application.Models.Department;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Application.Interfaces
{
    public interface IDepartmentApplicationService
    {
        Task<DepartmentResponseModel> CreateAsync(DepartmentCreateModel model);
        Task<DepartmentResponseModel> UpdateAsync(Guid id, DepartmentUpdateModel model);
        Task<IEnumerable<DepartmentResponseModel>> FindAllAsync(DepartmentQueryFilter filters);
        Task<DepartmentResponseModel> FindAsync(Guid id);
    }
}
