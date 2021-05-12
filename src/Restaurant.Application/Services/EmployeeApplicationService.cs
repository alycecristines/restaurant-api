using System.Threading.Tasks;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Entities;
using System.Collections.Generic;
using Restaurant.Domain.QueryFilters;
using System;
using AutoMapper;
using Restaurant.Application.Models.Employee;

namespace Restaurant.Application.Services
{
    public class EmployeeApplicationService : IEmployeeApplicationService
    {
        private readonly IEmployeeDomainService _employeeService;
        private readonly IAccountDomainService _accountService;
        private readonly IMapper _mapper;

        public EmployeeApplicationService(IEmployeeDomainService employeeService,
            IAccountDomainService accountService, IMapper mapper)
        {
            _employeeService = employeeService;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<EmployeeResponseModel> CreateAsync(EmployeeCreateModel model)
        {
            var newEmployee = _mapper.Map<Employee>(model);
            var createdEmployee = await _employeeService.CreateAsync(newEmployee);
            var createdUser = await _accountService.CreateAsync(createdEmployee);
            return _mapper.Map<EmployeeResponseModel>(createdEmployee);
        }

        public async Task<EmployeeResponseModel> UpdateAsync(Guid id, EmployeeUpdateModel model)
        {
            var newEmployee = _mapper.Map<Employee>(model);
            var updatedEmployee = await _employeeService.UpdateAsync(id, newEmployee);

            if (!updatedEmployee.CanAccessTheSystem()) await _accountService.DeleteAsync(updatedEmployee.Id);
            else if (await _accountService.Exists(updatedEmployee.Id)) await _accountService.UpdateAsync(updatedEmployee);
            else await _accountService.CreateAsync(updatedEmployee);

            return _mapper.Map<EmployeeResponseModel>(updatedEmployee);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> FindAllAsync(EmployeeQueryFilter filters)
        {
            var employees = await _employeeService.FindAllAsync(filters);
            return _mapper.Map<IEnumerable<EmployeeResponseModel>>(employees);
        }

        public async Task<EmployeeResponseModel> FindAsync(Guid id)
        {
            var employee = await _employeeService.FindAsync(id);
            return _mapper.Map<EmployeeResponseModel>(employee);
        }
    }
}
