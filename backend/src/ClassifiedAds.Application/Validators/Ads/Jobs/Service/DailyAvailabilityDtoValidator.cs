using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Application.Validators.Common;
using ClassifiedAds.Domain.Common.Enums;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs.Service;

public class DailyAvailabilityDtoValidator : AbstractValidator<DailyAvailabilityDto>
{
    public DailyAvailabilityDtoValidator()
    {
        // If DayWeek is provided, then IsAvailable should be provided
        RuleFor(x => x.DayWeek)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "يوم الأسبوع مطلوب",
                "ڕۆژی هەفتە پێویستە"));

        RuleFor(x => x.DayWeek!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "يوم الأسبوع غير صالح",
                "ڕۆژی هەفتە نادروستە"))
            .When(x => x.DayWeek.HasValue);

        // If DayWeek is provided, then IsAvailable is required
        RuleFor(x => x.IsAvailable)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة التوفر مطلوبة",
                "دۆخی بەردەستبوون پێویستە"))
            .When(x => x.DayWeek.HasValue);

        RuleFor(x => x.IsAvailable!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة التوفر غير صالحة",
                "دۆخی بەردەستبوون نادروستە"))
            .When(x => x.IsAvailable.HasValue);

        // If IsAvailable is No (0), then Is24Hours and TimeSlots should be null
        RuleFor(x => x.Is24Hours)
            .Null()
            .WithMessage(ValidationMessages.GetMessage(
                "لا يمكن تحديد ساعات العمل عندما تكون غير متاح",
                "ناتوانیت کاتژمێری کار دیاری بکەیت کاتێک بەردەست نیت"))
            .When(x => x.IsAvailable == YesNo.No);

        RuleFor(x => x.TimeSlots)
            .Null()
            .WithMessage(ValidationMessages.GetMessage(
                "لا يمكن تحديد فترات زمنية عندما تكون غير متاح",
                "ناتوانیت کاتی دیاری بکەیت کاتێک بەردەست نیت"))
            .When(x => x.IsAvailable == YesNo.No);

        // If IsAvailable is Yes (1), then Is24Hours should be provided
        RuleFor(x => x.Is24Hours)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "يجب تحديد إذا كنت تعمل 24 ساعة",
                "دەبێت دیاری بکەیت ئایا ٢٤ کاتژمێر کار دەکەیت"))
            .When(x => x.IsAvailable == YesNo.Yes);

        RuleFor(x => x.Is24Hours!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "قيمة 24 ساعة غير صالحة",
                "نرخی ٢٤ کاتژمێر نادروستە"))
            .When(x => x.Is24Hours.HasValue);

        // If IsAvailable is Yes and Is24Hours is No, then TimeSlots should be provided
        RuleFor(x => x.TimeSlots)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "يجب تحديد فترات زمنية عندما لا تعمل 24 ساعة",
                "دەبێت کاتی دیاری بکەیت کاتێک ٢٤ کاتژمێر کار ناکەیت"))
            .When(x => x.IsAvailable == YesNo.Yes && x.Is24Hours == YesNo.No);

        RuleFor(x => x.TimeSlots)
            .Must(ts => ts != null && ts.Count > 0)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب تحديد فترة زمنية واحدة على الأقل",
                "دەبێت لانیکەم یەک کات دیاری بکەیت"))
            .When(x => x.IsAvailable == YesNo.Yes && x.Is24Hours == YesNo.No);

        // If Is24Hours is Yes, then TimeSlots should be null or empty
        RuleFor(x => x.TimeSlots)
            .Must(ts => ts == null || ts.Count == 0)
            .WithMessage(ValidationMessages.GetMessage(
                "لا يمكن تحديد فترات زمنية عند العمل 24 ساعة",
                "ناتوانیت کاتی دیاری بکەیت کاتێک ٢٤ کاتژمێر کار دەکەیت"))
            .When(x => x.Is24Hours == YesNo.Yes);

        // Validate each time slot
        RuleForEach(x => x.TimeSlots)
            .SetValidator(new TimeSlotDtoValidator())
            .When(x => x.TimeSlots != null && x.TimeSlots.Count > 0);
    }
}
