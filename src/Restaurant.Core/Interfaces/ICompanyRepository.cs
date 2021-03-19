using System.Threading.Tasks;
using Restaurant.Core.Entities;

namespace Restaurant.Core.Interfaces
{
    public interface ICompanyRepository
    {
        Company Insert(Company entity);
        Task SaveChangesAsync();
    }
}
