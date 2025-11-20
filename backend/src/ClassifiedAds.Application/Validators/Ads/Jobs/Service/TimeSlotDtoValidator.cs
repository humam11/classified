using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs.Service;

public class TimeSlotDtoValidator : AbstractValidator<TimeSlotDto>
{
    public TimeSlotDtoValidator()
    {
        RuleFor(x => x.OpeningTime)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "وقت الافتتاح مطلوب",
                "کاتی کردنەوە پێویستە"))
            .Matches(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$")
            .WithMessage(ValidationMessages.GetMessage(
                "وقت الافتتاح يجب أن يكون بصيغة HH:mm",
                "کاتی کردنەوە دەبێت بە شێوەی HH:mm بێت"));

        RuleFor(x => x.ClosingTime)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "وقت الإغلاق مطلوب",
                "کاتی داخستن پێویستە"))
            .Matches(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$")
            .WithMessage(ValidationMessages.GetMessage(
                "وقت الإغلاق يجب أن يكون بصيغة HH:mm",
                "کاتی داخستن دەبێت بە شێوەی HH:mm بێت"));
    }
}
