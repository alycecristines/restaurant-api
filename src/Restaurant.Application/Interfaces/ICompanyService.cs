using System;
using System.Collections.Generic;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;

namespace Restaurant.Application.Interfaces
{
    public interface ICompanyService
    {
        void Insert(CompanyPostDTO dto);
        IEnumerable<CompanyResponseDTO> GetAll();
        IEnumerable<CompanyResponseDTO> GetAll(string nameOrRegistrationNumber);
        CompanyResponseDTO Get(Guid id);
        void Update(CompanyPutDTO dto);
        void Delete(Guid id);
    }
}
