using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;
using Restaurant.Application.Interfaces;
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

        public void Insert(CompanyPostDTO dto)
        {
            var currentEntity = GetAll(dto.RegistrationNumber);

            if (currentEntity.Any())
            {
                throw new BusinessException($"There is already a company registered with registration number '{dto.RegistrationNumber}'.");
            }

            var newEntity = _mapper.Map<Company>(dto);
            _repository.Insert(newEntity);
            _repository.SaveChanges();
        }

        public IEnumerable<CompanyResponseDTO> GetAll()
        {
            var entities = _repository.GetAll().Where(entity =>
                !entity.DeletedAt.HasValue).ToList();

            return _mapper.Map<IEnumerable<CompanyResponseDTO>>(entities);
        }

        public IEnumerable<CompanyResponseDTO> GetAll(string nameOrRegistrationNumber)
        {
            var entities = _repository.GetAll().Where(entity =>
                (entity.CorporateName.Contains(nameOrRegistrationNumber) ||
                entity.BusinessName.Contains(nameOrRegistrationNumber) ||
                entity.RegistrationNumber.Contains(nameOrRegistrationNumber)) &&
                !entity.DeletedAt.HasValue
            ).ToList();

            return _mapper.Map<IEnumerable<CompanyResponseDTO>>(entities);
        }

        public CompanyResponseDTO Get(Guid id)
        {
            var entity = _repository.Get(id);
            return _mapper.Map<CompanyResponseDTO>(entity);
        }

        public void Update(Guid id, CompanyPutDTO dto)
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
