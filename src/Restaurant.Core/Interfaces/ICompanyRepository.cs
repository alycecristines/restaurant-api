using System;
using System.Linq;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface ICompanyRepository
    {
        void Insert(Company entity);
        IQueryable<Company> GetAll();
        Company Get(Guid id);
        void SaveChanges();
    }
}
