using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IDepartmentRepository departmentRepository,
            IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public EmployeeResponseDTO Insert(EmployeePostDTO dto)
        {
            var department = _departmentRepository.Get(dto.DepartmentId.Value);

            if (department == null)
            {
                throw new BusinessException($"{nameof(Department)} not found with {nameof(Department.Id)} '{dto.DepartmentId.Value}'.");
            }

            var newEntity = _mapper.Map<Employee>(dto);

            _employeeRepository.Insert(newEntity);
            _employeeRepository.SaveChanges();

            return _mapper.Map<EmployeeResponseDTO>(newEntity);
        }

        public IEnumerable<EmployeeResponseDTO> GetAll(EmployeeQueryParams queryParams)
        {
            var query = _employeeRepository.GetAll();

            if (!queryParams.IncludeInactive)
            {
                query = query.Where(entity => !entity.DeletedAt.HasValue);
            }

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

            var entities = query.ToList();

            return _mapper.Map<IEnumerable<EmployeeResponseDTO>>(entities);
        }

        public EmployeeResponseDTO Get(Guid id)
        {
            var entity = _employeeRepository.Get(id);

            if (entity == null)
            {
                throw new BusinessException($"{nameof(Employee)} not found with {nameof(Employee.Id)} '{id}'.");
            }

            return _mapper.Map<EmployeeResponseDTO>(entity);
        }
    }
}
