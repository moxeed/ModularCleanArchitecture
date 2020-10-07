using Charity.Application.Module.Common;
using FluentValidation;

namespace Charity.Application.AdminModule.Commands.V1.AddPhilanthropist
{
    public class AddPhilanthropistRequestValidator : AbstractValidator<AddPhilanthropistRequest>
    {
        public AddPhilanthropistRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage(PersianErrorMessages.EmptyError);
            RuleFor(x => x.LastName).NotNull().WithMessage(PersianErrorMessages.EmptyError);
            RuleFor(x => x.Email).EmailAddress().WithMessage(PersianErrorMessages.InvalidFormat);
            RuleFor(x => x.Tel).NotEmpty().WithMessage(PersianErrorMessages.EmptyError);
            RuleFor(x => x.NationalCode).Length(10).WithMessage(PersianErrorMessages.LengthError);
            RuleFor(x => x.CityId).NotNull().WithMessage(PersianErrorMessages.EmptyError);
        }
    }
}