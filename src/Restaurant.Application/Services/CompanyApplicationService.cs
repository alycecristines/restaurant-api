using System.Threading.Tasks;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Entities;
using System.Collections.Generic;
using Restaurant.Domain.QueryFilters;
using System;
using Restaurant.Application.Models.Company;
using AutoMapper;

namespace Restaurant.Application.Services
{
    public class CompanyApplicationService : ICompanyApplicationService
    {
        private readonly ICompanyDomainService _companyService;
        private readonly IMapper _mapper;

        public CompanyApplicationService(ICompanyDomainService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<CompanyResponseModel> CreateAsync(CompanyCreateModel model)
        {
            var newCompany = _mapper.Map<Company>(model);
            var createdCompany = await _companyService.CreateAsync(newCompany);
            return _mapper.Map<CompanyResponseModel>(createdCompany);
        }

        public async Task<CompanyResponseModel> UpdateAsync(Guid id, CompanyUpdateModel model)
        {
            var newCompany = _mapper.Map<Company>(model);
            var updatedCompany = await _companyService.UpdateAsync(id, newCompany);
            return _mapper.Map<CompanyResponseModel>(updatedCompany);
        }

        public async Task<IEnumerable<CompanyResponseModel>> FindAllAsync(CompanyQueryFilter filters)
        {
            var companies = await _companyService.FindAllAsync(filters);
            return _mapper.Map<IEnumerable<CompanyResponseModel>>(companies);
        }

        public async Task<CompanyResponseModel> FindAsync(Guid id)
        {
            var company = await _companyService.FindAsync(id);
            return _mapper.Map<CompanyResponseModel>(company);
        }
    }
}
