using Application.Utilities.Validation;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.People.Create
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(person => person.Name).NotEmpty().WithMessage(ValidationMessages.IsRequired("نام"));
            RuleFor(person => person.Family).NotEmpty().WithMessage(ValidationMessages.IsRequired("نام خانوادگی"));
            RuleFor(person => person.NationalId).NotEmpty().Length(10).Matches(new Regex(@"^[0-9]+$")).WithMessage(ValidationMessages.IsRequired("کد ملی"));
            RuleFor(person => person.BirthDate).NotEmpty().LessThan(DateTime.Now).WithMessage(ValidationMessages.IsRequired("تاریخ تولد"));
        }
    }
}
