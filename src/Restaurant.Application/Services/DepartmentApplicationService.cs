using System.Threading.Tasks;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Entities;
using System.Collections.Generic;
using Restaurant.Domain.QueryFilters;
using System;
using AutoMapper;
using Restaurant.Application.Models.Department;

namespace Restaurant.Application.Services
{
    public class DepartmentApplicationService : IDepartmentApplicationService
    {
        private readonly IDepartmentDomainService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentApplicationService(IDepartmentDomainService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<DepartmentResponseModel> CreateAsync(DepartmentCreateModel model)
        {
            var newDepartment = _mapper.Map<Department>(model);
            var createdDepartment = await _departmentService.CreateAsync(newDepartment);
            return _mapper.Map<DepartmentResponseModel>(createdDepartment);
        }

        public async Task<DepartmentResponseModel> UpdateAsync(Guid id, DepartmentUpdateModel model)
        {
            var newDepartment = _mapper.Map<Department>(model);
            var updatedDepartment = await _departmentService.UpdateAsync(id, newDepartment);
            return _mapper.Map<DepartmentResponseModel>(updatedDepartment);
        }

        public async Task<IEnumerable<DepartmentResponseModel>> FindAllAsync(DepartmentQueryFilter filters)
        {
            var departments = await _departmentService.FindAllAsync(filters);
            return _mapper.Map<IEnumerable<DepartmentResponseModel>>(departments);
        }

        public async Task<DepartmentResponseModel> FindAsync(Guid id)
        {
            var department = await _departmentService.FindAsync(id);
            return _mapper.Map<DepartmentResponseModel>(department);
        }
    }
}
