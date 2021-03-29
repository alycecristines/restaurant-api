using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Restaurant.Application.DTOs.Department;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    // TODO: Refactor
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IServiceValidator _validator;
        private readonly IMapper _mapper;

        public DepartmentService(IRepository<Department> departmentRepository,
            IRepository<Company> companyRepository, IRepository<Employee> employeeRepository,
            IServiceValidator validator, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public DepartmentResponseDTO Insert(DepartmentPostDTO dto)
        {
            var company = _companyRepository.Get(dto.CompanyId.Value);

            _validator.Found(company);
            _validator.NotDeleted(company);

            var newEntity = _mapper.Map<Department>(dto);

            _departmentRepository.Insert(newEntity);
            _departmentRepository.SaveChanges();

            return _mapper.Map<DepartmentResponseDTO>(newEntity);
        }

        public IEnumerable<DepartmentResponseDTO> GetAll(DepartmentQueryParams queryParams)
        {
            var query = _departmentRepository.GetAll(queryParams.IncludeInactive);

            if (!string.IsNullOrWhiteSpace(queryParams.Description))
            {
                query = query.Where(entity =>
                    entity.Description.ContainsResearch(queryParams.Description));
            }

            if (queryParams.CompanyId.HasValue)
            {
                query = query.Where(entity =>
                    entity.CompanyId == queryParams.CompanyId);
            }

            var entities = query.ToList();

            return _mapper.Map<IEnumerable<DepartmentResponseDTO>>(entities);
        }

        public DepartmentResponseDTO Get(Guid id)
        {
            var entity = _departmentRepository.Get(id);

            _validator.Found(entity);

            return _mapper.Map<DepartmentResponseDTO>(entity);
        }

        public DepartmentResponseDTO Update(Guid id, DepartmentPutDTO dto)
        {
            var currentEntity = _departmentRepository.Get(id);

            _validator.Found(currentEntity);
            _validator.NotDeleted(currentEntity);

            var updatedEntity = _mapper.Map(dto, currentEntity);

            updatedEntity.Update(DateTime.UtcNow);
            _departmentRepository.SaveChanges();

            return _mapper.Map<DepartmentResponseDTO>(updatedEntity);
        }

        public void Delete(Guid id)
        {
            var entity = _departmentRepository.Get(id);

            _validator.Found(entity);
            _validator.NotDeleted(entity);

            var relatedEmployee = _employeeRepository.GetAll()
                .FirstOrDefault(entity => entity.DepartmentId == id);

            _validator.NotRelated(relatedEmployee);

            entity.Delete(DateTime.UtcNow);
            _departmentRepository.SaveChanges();
        }
    }
}
