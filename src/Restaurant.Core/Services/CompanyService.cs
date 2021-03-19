using System.Threading.Tasks;
using Restaurant.Core.Entities;
using Restaurant.Core.Interfaces;

namespace Restaurant.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> Insert(Company entity)
        {
            // TODO: Check if there is no registration with the same RegistrationNumber
            var inserted = _repository.Insert(entity);
            await _repository.SaveChangesAsync();
            return inserted;
        }
    }
}
