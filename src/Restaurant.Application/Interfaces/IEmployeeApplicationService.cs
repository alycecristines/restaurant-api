using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Application.Models.Employee;
using Restaurant.Domain.QueryFilters;

namespace Restaurant.Application.Interfaces
{
    public interface IEmployeeApplicationService
    {
        Task<EmployeeResponseModel> CreateAsync(EmployeeCreateModel model);
        Task<EmployeeResponseModel> UpdateAsync(Guid id, EmployeeUpdateModel model);
        Task<IEnumerable<EmployeeResponseModel>> FindAllAsync(EmployeeQueryFilter filters);
        Task<EmployeeResponseModel> FindAsync(Guid id);
    }
}
