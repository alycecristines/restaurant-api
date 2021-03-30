using System;
using System.Collections.Generic;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IProductService
    {
        Product Insert(Product newProduct);
        IEnumerable<Product> GetAll(ProductQueryParams queryParams);
        Product Get(Guid id);
        Product Update(Guid id, Product newProduct);
        void Delete(Guid id);
    }
}
