using FluentValidation;
using ShopCore31.Application.Cart;

namespace ShopCore31.UI.ValidationContexts
{
    public class AddCustomerInformationRequestValidation
        : AbstractValidator<AddCustomerInformation.Request>
    {
        public AddCustomerInformationRequestValidation()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.PhoneNumber).NotNull().MinimumLength(7);
            RuleFor(x => x.Address1).NotNull();
            RuleFor(x => x.City).NotNull();
            RuleFor(x => x.ZipCode).NotNull();
        }
    }
}
