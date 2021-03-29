using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Restaurant.Application.DTOs.Employee;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    // TODO: Refactor
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IServiceValidator _validator;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> employeeRepository,
            IRepository<Department> departmentRepository, IServiceValidator validator, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public EmployeeResponseDTO Insert(EmployeePostDTO dto)
        {
            var department = _departmentRepository.Get(dto.DepartmentId.Value);

            _validator.Found(department);
            _validator.NotDeleted(department);

            var newEntity = _mapper.Map<Employee>(dto);

            _employeeRepository.Insert(newEntity);
            _employeeRepository.SaveChanges();

            return _mapper.Map<EmployeeResponseDTO>(newEntity);
        }

        public IEnumerable<EmployeeResponseDTO> GetAll(EmployeeQueryParams queryParams)
        {
            var query = _employeeRepository.GetAll(queryParams.IncludeInactive);

            if (!string.IsNullOrWhiteSpace(queryParams.Name))
            {
                query = query.Where(entity =>
                    entity.Name.ContainsResearch(queryParams.Name));
            }

            if (!string.IsNullOrWhiteSpace(queryParams.Email))
            {
                query = query.Where(entity =>
                    entity.Email.ContainsResearch(queryParams.Email));
            }

            if (queryParams.DepartmentId.HasValue)
            {
                query = query.Where(entity =>
                    entity.DepartmentId == queryParams.DepartmentId);
            }

            var entities = query.ToList();

            return _mapper.Map<IEnumerable<EmployeeResponseDTO>>(entities);
        }

        public EmployeeResponseDTO Get(Guid id)
        {
            var entity = _employeeRepository.Get(id);

            _validator.Found(entity);

            return _mapper.Map<EmployeeResponseDTO>(entity);
        }

        public EmployeeResponseDTO Update(Guid id, EmployeePutDTO dto)
        {
            var department = _departmentRepository.Get(dto.DepartmentId.Value);

            _validator.Found(department);
            _validator.NotDeleted(department);

            var currentEntity = _employeeRepository.Get(id);

            _validator.Found(currentEntity);
            _validator.NotDeleted(currentEntity);

            var updatedEntity = _mapper.Map(dto, currentEntity);

            updatedEntity.Update(DateTime.UtcNow);
            _employeeRepository.SaveChanges();

            return _mapper.Map<EmployeeResponseDTO>(updatedEntity);
        }

        public void Delete(Guid id)
        {
            var entity = _employeeRepository.Get(id);

            _validator.Found(entity);
            _validator.NotDeleted(entity);

            entity.Delete(DateTime.UtcNow);
            _employeeRepository.SaveChanges();
        }
    }
}
