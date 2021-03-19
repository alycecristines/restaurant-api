using System.Threading.Tasks;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> Insert(Company entity);
    }
}
