using FluentValidation;
using Flyon.IServices.Requests;

namespace Flyon.Api.Validation
{
    public class EditPostValidator : AbstractValidator<EditPost> 
    {
        public EditPostValidator() {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.OfferCountry).NotNull();
            RuleFor(x => x.OfferCity).NotNull();
            RuleFor(x => x.OfferDescription).NotNull();
            RuleFor(x => x.OfferCost).NotNull();
            RuleFor(x => x.OfferPhotoHref).NotNull();
        }
    }
}