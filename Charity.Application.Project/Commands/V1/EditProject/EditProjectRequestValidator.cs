using FluentValidation;
using Charity.Application.ProjectModule.DTOs.V1;

namespace Charity.Application.ProjectModule.Commands.V1.EditProject
{
    public class EditProjectRequestValidator : AbstractValidator<EditProjectRequest>
    {
        public EditProjectRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("id اجباری است");
            RuleFor(x => x.Title).NotEmpty().MinimumLength(30);
        }
    }
}
