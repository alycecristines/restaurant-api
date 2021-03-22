using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
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
                throw new BusinessException($"There is already a company registered with registration number '{dto.RegistrationNumber}'.");
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
                    entity.CorporateName.Contains(queryParams.Name) ||
                    entity.BusinessName.Contains(queryParams.Name));
            }

            if (!string.IsNullOrWhiteSpace(queryParams.RegistrationNumber))
            {
                query = query.Where(entity => entity.RegistrationNumber.Contains(queryParams.RegistrationNumber));
            }

            var entities = query.ToList();

            return _mapper.Map<IEnumerable<CompanyResponseDTO>>(entities);
        }

        public CompanyResponseDTO Get(Guid id)
        {
            var entity = _repository.Get(id);

            return _mapper.Map<CompanyResponseDTO>(entity);
        }

        public CompanyResponseDTO Update(Guid id, CompanyPutDTO dto)
        {
            var currentEntity = _repository.Get(id);

            if (currentEntity == null)
            {
                throw new BusinessException($"Company not found with id '{id}'.");
            }

            if (currentEntity.Deleted)
            {
                throw new BusinessException($"The company with the id '{id}' has been deleted.");
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
                throw new BusinessException($"Company not found with id '{id}'.");
            }

            if (entity.Deleted)
            {
                throw new BusinessException("This company has already been deleted.");
            }

            entity.Delete(DateTime.UtcNow);
            _repository.SaveChanges();
        }
    }
}
