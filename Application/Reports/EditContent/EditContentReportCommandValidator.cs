using Application.Utilities.Validation;
using FluentValidation;

namespace Application.Reports.EditContent
{
    public class EditContentReportCommandValidator : AbstractValidator<EditContentReportCommand>
    {
        public EditContentReportCommandValidator()
        {
            RuleFor(report => report.Content).NotEmpty().MinimumLength(5).WithMessage(ValidationMessages.HasMinLength("محتوای گزارش", 5));
        }
    }
}
