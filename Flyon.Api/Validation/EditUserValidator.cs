using FluentValidation;
using Flyon.IServices.Requests;

namespace Flyon.Api.Validation
{
    public class EditUserValidator : AbstractValidator<EditUser> {
        public EditUserValidator() {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Gender).NotNull();
        }
    }
}