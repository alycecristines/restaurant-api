using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Restaurant.Application.DTOs.Company;
using Restaurant.Application.Extensions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Application.Services
{
    // TODO: Refactor
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IServiceValidator _validator;
        private readonly IMapper _mapper;

        public CompanyService(IRepository<Company> companyRepository,
            IRepository<Department> departmentRepository, IServiceValidator validator, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _departmentRepository = departmentRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public CompanyResponseDTO Insert(CompanyPostDTO dto)
        {
            var currentEntity = _companyRepository.GetAll()
                .FirstOrDefault(entity => entity.RegistrationNumber == dto.RegistrationNumber);

            _validator.NotDuplicated(currentEntity);

            var newEntity = _mapper.Map<Company>(dto);

            _companyRepository.Insert(newEntity);
            _companyRepository.SaveChanges();

            return _mapper.Map<CompanyResponseDTO>(newEntity);
        }

        public IEnumerable<CompanyResponseDTO> GetAll(CompanyQueryParams queryParams)
        {
            var query = _companyRepository.GetAll(queryParams.IncludeInactive);

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
            var entity = _companyRepository.Get(id);

            _validator.Found(entity);

            return _mapper.Map<CompanyResponseDTO>(entity);
        }

        public CompanyResponseDTO Update(Guid id, CompanyPutDTO dto)
        {
            var currentEntity = _companyRepository.Get(id);

            _validator.Found(currentEntity);
            _validator.NotDeleted(currentEntity);

            var updatedEntity = _mapper.Map(dto, currentEntity);

            updatedEntity.Update(DateTime.UtcNow);
            _companyRepository.SaveChanges();

            return _mapper.Map<CompanyResponseDTO>(updatedEntity);
        }

        public void Delete(Guid id)
        {
            var entity = _companyRepository.Get(id);

            _validator.Found(entity);
            _validator.NotDeleted(entity);

            var relatedDepartment = _departmentRepository.GetAll()
                .FirstOrDefault(entity => entity.CompanyId == id);

            _validator.NotRelated(relatedDepartment);

            entity.Delete(DateTime.UtcNow);
            _companyRepository.SaveChanges();
        }
    }
}
