using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Company>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<IEnumerable<Company>> GetAsync(string nameOrRegistrationNumber)
        {
            return await _repository.GetAsync(nameOrRegistrationNumber);
        }

        public async Task<Company> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _repository.GetAsync(id);

            if (entity is null) throw new InvalidOperationException($"Company not found with id '{id}'.");
            if (entity.DeletedAt.HasValue) throw new InvalidOperationException("This company has already been deleted.");

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
