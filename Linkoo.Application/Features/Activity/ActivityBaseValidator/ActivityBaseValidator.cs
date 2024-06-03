using FluentValidation;
using Linkoo.Application.Features.Activity.ActivityBaseDtos;

namespace Linkoo.Application.Features.Activity.ActivityBaseValidator
{
    public class ActivityBaseValidator<T> : AbstractValidator<T> where T : ActivityBaseDto
    {
        public ActivityBaseValidator()
        {
             RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2).WithMessage("{PropertyName} minimum length is 2 characters")
                .MaximumLength(100).WithMessage("{PropertyName} maximum length is 100 characters");

             RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(2).WithMessage("{PropertyName} minimum length is 2 characters")
                .MaximumLength(500).WithMessage("{PropertyName} maximum length is 500 characters");
            
            RuleFor(x => x.Category)
                .NotEmpty();

            RuleFor(x => x.City)
                .NotEmpty();

            RuleFor(x => x.Venue)
                .NotEmpty();
            
        }
    }
}