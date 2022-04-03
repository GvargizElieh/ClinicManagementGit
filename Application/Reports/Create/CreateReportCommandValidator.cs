using Application.Utilities.Validation;
using FluentValidation;

namespace Application.Reports.Create
{
    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator()
        {
            RuleFor(report => report.Issue).NotEmpty().WithMessage(ValidationMessages.IsRequired("عنوان گزارش"));
            RuleFor(report => report.Content).NotEmpty().MinimumLength(5).WithMessage(ValidationMessages.HasMinLength("محتوای گزارش", 5));
        }
    }
}
