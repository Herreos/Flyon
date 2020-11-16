using FluentValidation;
using Flyon.IServices.Requests;

namespace Flyon.Api.Validation
{
    public class CreateUserValidator: AbstractValidator<CreateUser>
    {
        public CreateUserValidator() {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Gender).NotNull();
        }
    }

}