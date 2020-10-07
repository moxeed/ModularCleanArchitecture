using FluentValidation;

namespace Charity.Application.ProjectModule.Queries.V1.GetProjectsByType
{
    public class GetProjectsByTypeRequestValidator : AbstractValidator<GetProjectsByTypeQueryRequest>
    {
        public GetProjectsByTypeRequestValidator()
        {
            RuleFor(x => x.TypeId).NotNull().WithMessage("نوع پروژه نادرست است");
        }
    }
}