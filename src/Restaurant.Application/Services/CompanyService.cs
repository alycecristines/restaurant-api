using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Restaurant.Application.DTOs.Company;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    // TODO: Refactor
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _repository;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public CompanyService(IRepository<Company> repository,
            IDepartmentService departmentService, IMapper mapper)
        {
            _repository = repository;
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public CompanyResponseDTO Insert(CompanyPostDTO dto)
        {
            var queryParams = new CompanyQueryParams
            {
                RegistrationNumber = dto.RegistrationNumber
            };

            var currentEntity = GetAll(queryParams);

            if (currentEntity.Any())
            {
                throw new BusinessException($"There is already a {nameof(Company)} registered with {nameof(Company.RegistrationNumber)} '{dto.RegistrationNumber}'.");
            }

            var newEntity = _mapper.Map<Company>(dto);

            _repository.Insert(newEntity);
            _repository.SaveChanges();

            return _mapper.Map<CompanyResponseDTO>(newEntity);
        }

        public IEnumerable<CompanyResponseDTO> GetAll(CompanyQueryParams queryParams)
        {
            var query = _repository.GetAll();

            if (!queryParams.IncludeInactive)
            {
                query = query.Where(entity => !entity.DeletedAt.HasValue);
            }

            if (!string.IsNullOrWhiteSpace(queryParams.Name))
            {
                query = query.Where(entity =>
                    entity.CorporateName.ContainsResearch(queryParams.Name) ||
                    entity.BusinessName.ContainsResearch(queryParams.Name));
            }

            if (!string.IsNullOrWhiteSpace(queryParams.RegistrationNumber))
            {
                query = query.Where(entity => entity.RegistrationNumber.ContainsResearch(queryParams.RegistrationNumber));
            }

            var entities = query.ToList();

            return _mapper.Map<IEnumerable<CompanyResponseDTO>>(entities);
        }

        public CompanyResponseDTO Get(Guid id)
        {
            var entity = _repository.Get(id);

            if (entity == null)
            {
                throw new BusinessException($"{nameof(Company)} not found with {nameof(Company.Id)} '{id}'.");
            }

            return _mapper.Map<CompanyResponseDTO>(entity);
        }

        public CompanyResponseDTO Update(Guid id, CompanyPutDTO dto)
        {
            var currentEntity = _repository.Get(id);

            if (currentEntity == null)
            {
                throw new BusinessException($"{nameof(Company)} not found with {nameof(Company.Id)} '{id}'.");
            }

            if (currentEntity.Deleted)
            {
                throw new BusinessException($"The {nameof(Company)} with the {nameof(Company.Id)} '{id}' has been deleted.");
            }

            var updatedEntity = _mapper.Map(dto, currentEntity);

            updatedEntity.Update(DateTime.UtcNow);
            _repository.SaveChanges();

            return _mapper.Map<CompanyResponseDTO>(updatedEntity);
        }

        public void Delete(Guid id)
        {
            var entity = _repository.Get(id);

            if (entity == null)
            {
                throw new BusinessException($"{nameof(Company)} not found with {nameof(Company.Id)} '{id}'.");
            }

            if (entity.Deleted)
            {
                throw new BusinessException($"This {nameof(Company)} has already been deleted.");
            }

            var queryParams = new DepartmentQueryParams
            {
                CompanyId = id
            };

            var departments = _departmentService.GetAll(queryParams);

            if (departments.Any())
            {
                throw new BusinessException($"There are related {nameof(Department)}s.");
            }

            entity.Delete(DateTime.UtcNow);
            _repository.SaveChanges();
        }
    }
}
