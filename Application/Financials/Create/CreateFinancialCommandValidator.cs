using Application.Utilities.Validation;
using FluentValidation;

namespace Application.Financials.Create
{
    public class CreateFinancialCommandValidator : AbstractValidator<CreateFinancialCommand>
    {
        public CreateFinancialCommandValidator()
        {
            RuleFor(financial => financial.Payment).NotEmpty().WithMessage(ValidationMessages.IsRequired("عنوان پرداخت"));
            RuleFor(financial => financial.PaymentAmount).NotEmpty().GreaterThan(0).WithMessage(ValidationMessages.IsRequired("مبلغ قابل پرداخت"));
        }
    }
}
