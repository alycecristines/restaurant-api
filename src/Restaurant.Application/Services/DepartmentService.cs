using AutoMapper;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.Interfaces;
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

        public void Insert(DepartmentRequestDTO dto)
        {
            var company = _companyRepository.Get(dto.CompanyId.Value);

            if (company == null)
            {
                throw new BusinessException($"Company not found with id '{dto.CompanyId.Value}'.");
            }

            var newEntity = _mapper.Map<Department>(dto);
            _departmentRepository.Insert(newEntity);
            _departmentRepository.SaveChanges();
        }
    }
}
