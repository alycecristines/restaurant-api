using AutoMapper;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;
using Restaurant.Application.Interfaces;
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
    }
}
