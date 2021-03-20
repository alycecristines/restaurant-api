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

        public async Task Insert(Company newEntity)
        {
            // TODO: Check if there is no registration with the same RegistrationNumber
            _repository.Insert(newEntity);
            await _repository.SaveChangesAsync();
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

        public async Task Update(Company updatedEntity)
        {
            var entity = await _repository.GetAsync(updatedEntity.Id);

            if (entity is null) throw new InvalidOperationException($"Company not found with id '{updatedEntity.Id}'.");

            entity.CorporateName = updatedEntity.CorporateName;
            entity.BusinessName = updatedEntity.BusinessName;
            entity.Phone.AreaCode = updatedEntity.Phone.AreaCode;
            entity.Phone.Number = updatedEntity.Phone.Number;
            entity.Address.Street = updatedEntity.Address.Street;
            entity.Address.Secondary = updatedEntity.Address.Secondary;
            entity.Address.BuildingNumber = updatedEntity.Address.BuildingNumber;
            entity.Address.District = updatedEntity.Address.District;
            entity.Address.City = updatedEntity.Address.City;
            entity.Address.State = updatedEntity.Address.State;
            entity.Address.Country = updatedEntity.Address.Country;
            entity.Address.ZipCode = updatedEntity.Address.ZipCode;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();
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
