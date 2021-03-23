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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository,
            ICompanyRepository companyRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public DepartmentResponseDTO Insert(DepartmentRequestDTO dto)
        {
            var company = _companyRepository.Get(dto.CompanyId.Value);

            if (company == null)
            {
                throw new BusinessException($"{nameof(Company)} not found with {nameof(Company.Id)} '{dto.CompanyId.Value}'.");
            }

            var newEntity = _mapper.Map<Department>(dto);

            _departmentRepository.Insert(newEntity);
            _departmentRepository.SaveChanges();

            return _mapper.Map<DepartmentResponseDTO>(newEntity);
        }

        public IEnumerable<DepartmentResponseDTO> GetAll(DepartmentQueryParams queryParams)
        {
            var query = _departmentRepository.GetAll();

            if (!queryParams.IncludeInactive)
            {
                query = query.Where(entity => !entity.DeletedAt.HasValue);
            }

            if (!string.IsNullOrWhiteSpace(queryParams.Description))
            {
                query = query.Where(entity =>
                    entity.Description.ContainsResearch(queryParams.Description));
            }

            var entities = query.ToList();

            return _mapper.Map<IEnumerable<DepartmentResponseDTO>>(entities);
        }

        public DepartmentResponseDTO Get(Guid id)
        {
            var entity = _departmentRepository.Get(id);

            if (entity == null)
            {
                throw new BusinessException($"{nameof(Department)} not found with {nameof(Department.Id)} '{id}'.");
            }

            return _mapper.Map<DepartmentResponseDTO>(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _departmentRepository.Get(id);

            if (entity == null)
            {
                throw new BusinessException($"{nameof(Department)} not found with {nameof(Department.Id)} '{id}'.");
            }

            if (entity.Deleted)
            {
                throw new BusinessException($"This {nameof(Department)} has already been deleted.");
            }

            entity.Delete(DateTime.UtcNow);
            _departmentRepository.SaveChanges();
        }
    }
}
