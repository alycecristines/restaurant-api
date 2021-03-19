using FluentValidation;
using Restaurant.Core.Entities;

namespace Restaurant.Infrastructure.Validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CorporateName).NotNull().MaximumLength(150);
            RuleFor(x => x.BusinessName).NotNull().MaximumLength(150);
            RuleFor(x => x.RegistrationNumber).NotNull().Length(14).Matches(@"^\d*$");

            RuleFor(x => x.Phone).NotNull();
            RuleFor(x => x.Phone.AreaCode).NotNull().Length(2).Matches(@"^\d*$").When(PhoneIsNotNull);
            RuleFor(x => x.Phone.Number).NotNull().MinimumLength(8).MaximumLength(9).Matches(@"^\d*$").When(PhoneIsNotNull);

            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.Address.Street).NotNull().MaximumLength(100).When(AddressIsNotNull);
            RuleFor(x => x.Address.Secondary).NotNull().MaximumLength(100).When(AddressIsNotNull);
            RuleFor(x => x.Address.BuildingNumber).NotNull().MaximumLength(3).When(AddressIsNotNull);
            RuleFor(x => x.Address.District).NotNull().MaximumLength(50).When(AddressIsNotNull);
            RuleFor(x => x.Address.City).NotNull().MaximumLength(50).When(AddressIsNotNull);
            RuleFor(x => x.Address.State).NotNull().MaximumLength(50).When(AddressIsNotNull);
            RuleFor(x => x.Address.Country).NotNull().MaximumLength(50).When(AddressIsNotNull);
            RuleFor(x => x.Address.ZipCode).NotNull().MaximumLength(8).Matches(@"^\d*$").When(AddressIsNotNull);
        }

        private bool PhoneIsNotNull(Company company) => company.Phone != null;
        private bool AddressIsNotNull(Company company) => company.Address != null;
    }
}
