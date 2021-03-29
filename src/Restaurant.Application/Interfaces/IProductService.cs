using System;
using System.Collections.Generic;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IProductService
    {
        Product Insert(Product dto);
        IEnumerable<Product> GetAll(ProductQueryParams queryParams);
        Product Get(Guid id);
        Product Update(Guid id, Product dto);
        void Delete(Guid id);
    }
}
