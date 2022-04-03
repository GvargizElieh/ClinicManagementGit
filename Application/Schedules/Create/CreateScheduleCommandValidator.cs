using Application.Utilities.Validation;
using FluentValidation;

namespace Application.Schedules.Create
{
    public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleCommandValidator()
        {
            RuleFor(schedule => schedule.Title).NotEmpty().WithMessage(ValidationMessages.IsRequired("عنوان"));
            RuleFor(schedule => schedule.StartTime).NotEmpty().GreaterThan(DateTime.Now).WithMessage("زمان شروع نوبت نباید گذشته باشد");
            RuleFor(schedule => schedule.EndTime).GreaterThan(schedule => schedule.StartTime).WithMessage("زمان پایان باید بعد از زمان شروع باشد");
        }
    }
}
