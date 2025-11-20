using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs.Service;

public class ServiceAdDtoValidator : AbstractValidator<ServiceAdDto>
{
    public ServiceAdDtoValidator()
    {
        // Include base ad validation for updates
        Include(new AdDtoBaseValidator());

        // Service-specific validation (optional when provided)
        RuleFor(x => x.PaymentPeriod!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "طريقة الدفع غير صالحة",
                "شێوازی پارەدان نادروستە"))
            .When(x => x.PaymentPeriod.HasValue);

        // Validate nested collections
        RuleForEach(x => x.DailyAvailability)
            .SetValidator(new DailyAvailabilityDtoValidator())
            .When(x => x.DailyAvailability != null);
    }
}

public class CreateServiceAdDtoValidator : AbstractValidator<CreateServiceAdDto>
{
    public CreateServiceAdDtoValidator()
    {
        // Include Service-specific validation
        Include(new ServiceAdDtoValidator());

        // Apply standard create rules but with local price only (IQD)
        this.ApplyCreateLocalPriceRules();

        // Required Service-specific fields
        RuleFor(x => x.PaymentPeriod)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "طريقة الدفع مطلوبة",
                "شێوازی پارەدان پێویستە"));


        RuleFor(x => x.DailyAvailability)
            .Must(da => da != null && da.Count > 0)
            .WithMessage(ValidationMessages.GetMessage(
                "مطلوب توفر يوم واحد على الأقل",
                "لانیکەم بەردەستبوونی یەک ڕۆژ پێویستە"));
    }
}
