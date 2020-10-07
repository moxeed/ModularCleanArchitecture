using Charity.Application.ProjectModule.DTOs.V1;
using FluentValidation;

namespace Charity.Application.ProjectModule.Commands.V1.AddProject
{
    public class AddProjectRequestValidator : AbstractValidator<AddProjectRequest>
    {
        public AddProjectRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(30);
        }
    }
}
