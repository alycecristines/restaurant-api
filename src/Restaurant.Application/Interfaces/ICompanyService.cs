using System;
using System.Collections.Generic;
using Restaurant.Application.DTOs.Request;
using Restaurant.Application.DTOs.Response;
using Restaurant.Application.QueryParams;

namespace Restaurant.Application.Interfaces
{
    public interface ICompanyService
    {
        CompanyResponseDTO Insert(CompanyPostDTO dto);
        IEnumerable<CompanyResponseDTO> GetAll(CompanyQueryParams queryParams);
        CompanyResponseDTO Get(Guid id);
        CompanyResponseDTO Update(Guid id, CompanyPutDTO dto);
        void Delete(Guid id);
    }
}
