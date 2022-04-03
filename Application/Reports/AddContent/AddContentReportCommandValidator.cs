using Application.Utilities.Validation;
using FluentValidation;

namespace Application.Reports.AddContent
{
    public class AddContentReportCommandValidator : AbstractValidator<AddContentReportCommand>
    {
        public AddContentReportCommandValidator()
        {
            RuleFor(report => report.Content).NotEmpty().WithMessage(ValidationMessages.IsRequired("محتوای گزارش"));
        }
    }
}
