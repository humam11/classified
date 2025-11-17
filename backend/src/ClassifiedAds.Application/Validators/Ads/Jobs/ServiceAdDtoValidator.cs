using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs;

public class ServiceAdDtoValidator : AbstractValidator<ServiceAdDto>
{
    public ServiceAdDtoValidator()
    {
        // Include(new CreateAdLocalPriceOnlyValidator()); // Service must be in IQD only

        RuleFor(x => x.PaymentPeriod)
            .IsValidEnum();

        RuleFor(x => x.DailyAvailability)
            .NotNull().WithMessage(ValidationMessages.GetMessage(
                // Daily availability is required
                "التوفر اليومي مطلوب",
                "بەردەستبوونی ڕۆژانە پێویستە"))
            .Must(da => da != null && da.Count > 0)
            .WithMessage(ValidationMessages.GetMessage(
                // At least one day availability is required
                "مطلوب توفر يوم واحد على الأقل",
                "لانیکەم بەردەستبوونی یەک ڕۆژ پێویستە"));

        RuleForEach(x => x.DailyAvailability)
            .Must(da => da.Is24Hours != Domain.Common.Enums.YesNo.Yes || da.TimeSlots == null || da.TimeSlots.Count == 0)
            .WithMessage(ValidationMessages.GetMessage(
                // You cannot specify time slots when working 24 hours
                "لا يمكنك تحديد فترات زمنية عند العمل 24 ساعة",
                "ناتوانیت کاتی دیاری بکەیت کاتێک ٢٤ کاتژمێر کار دەکەیت"));
    }
}
