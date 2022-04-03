using Application.Utilities.Validation;
using FluentValidation;

namespace Application.Financials.Pay
{
    public class PayFinancialCommandValidator : AbstractValidator<PayFinancialCommand>
    {
        public PayFinancialCommandValidator()
        {
            RuleFor(financial => financial.PayAmount).NotEmpty().GreaterThan(0).WithMessage(ValidationMessages.IsRequired("مبلغ پرداختی"));
        }
    }
}
