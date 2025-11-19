using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Electronics;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class ComputerAdDtoMapper
{
    public static Computer MapToEntity(
        CreateComputerAdDto dto,
        string slug,
        Guid userId,
        List<ushort> categoryIds,
        byte categoryJoins,
        List<ushort> locationIds,
        string fullAddressArabic,
        string fullAddressKurdish)
    {
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
        {
            throw new ArgumentException("Required fields are missing");
        }

        string showingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new Computer
        {
            Title = dto.Title,
            Description = dto.Description ?? string.Empty,
            Price = new Price
            {
                IsDollar = dto.IsDollar.Value,
                Value = dto.PriceValue.Value,
                ShowingPrice = showingPrice
            },
            Category = new Category
            {
                CategoryJoins = categoryJoins,
                CategoryIds = categoryIds
            },
            LocationAd = new LocationAd
            {
                LocationIds = locationIds,
                Street = dto.Street,
                FullAddressArabic = fullAddressArabic,
                FullAddressKurdish = fullAddressKurdish
            },
            Images = new List<AdImage>(),
            Status = Status.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            ImageCount = 0,
            ViewsCount = 0,
            UserId = userId,
            Priority = 0,
            Slug = slug,
            IsNew = dto.IsNew,
            WarrantyMonths = dto.WarrantyMonths,
            CPU = dto.CPU,
            RamSize = dto.RamSize,
            IsSSD = dto.IsSSD,
            StorageCapacity = dto.StorageCapacity,
            GraphicsCard = dto.GraphicsCard,
            UsbPorts = dto.UsbPorts,
            HdmiPorts = dto.HdmiPorts
        };
    }

    public static CreateComputerAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateComputerAdDto
        {
            Title = baseDto.Title,
            Description = baseDto.Description,
            IsDollar = baseDto.IsDollar,
            PriceValue = baseDto.PriceValue,
            City = baseDto.City,
            Region = baseDto.Region,
            Neighborhood = baseDto.Neighborhood,
            Street = baseDto.Street,
            ImageFiles = baseDto.ImageFiles,
            IsNew = form.TryGetValue("IsNew", out var isNew) &&
                   !string.IsNullOrWhiteSpace(isNew) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isNew, out var yn) ? yn : null,
            WarrantyMonths = form.TryGetValue("WarrantyMonths", out var warranty) &&
                            !string.IsNullOrWhiteSpace(warranty) &&
                            byte.TryParse(warranty, out var wm) ? wm : null,
            CPU = form.TryGetValue("CPU", out var cpu) && !string.IsNullOrWhiteSpace(cpu) ? cpu.ToString() : null,
            RamSize = form.TryGetValue("RamSize", out var ramSize) &&
                     !string.IsNullOrWhiteSpace(ramSize) &&
                     Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.RamSize>(ramSize, out var rs) ? rs : null,
            IsSSD = form.TryGetValue("IsSSD", out var isSSD) &&
                   !string.IsNullOrWhiteSpace(isSSD) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isSSD, out var ssd) ? ssd : null,
            StorageCapacity = form.TryGetValue("StorageCapacity", out var storage) &&
                             !string.IsNullOrWhiteSpace(storage) &&
                             Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(storage, out var sc) ? sc : null,
            GraphicsCard = form.TryGetValue("GraphicsCard", out var gpu) && !string.IsNullOrWhiteSpace(gpu) ? gpu.ToString() : null,
            UsbPorts = form.TryGetValue("UsbPorts", out var usb) &&
                      !string.IsNullOrWhiteSpace(usb) &&
                      byte.TryParse(usb, out var up) ? up : null,
            HdmiPorts = form.TryGetValue("HdmiPorts", out var hdmi) &&
                       !string.IsNullOrWhiteSpace(hdmi) &&
                       byte.TryParse(hdmi, out var hp) ? hp : null
        };
    }

    public static ComputerAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new ComputerAdDto
        {
            Title = baseDto.Title,
            Description = baseDto.Description,
            IsDollar = baseDto.IsDollar,
            PriceValue = baseDto.PriceValue,
            City = baseDto.City,
            Region = baseDto.Region,
            Neighborhood = baseDto.Neighborhood,
            Street = baseDto.Street,
            ImageFiles = baseDto.ImageFiles,
            IsNew = form.TryGetValue("IsNew", out var isNew) &&
                   !string.IsNullOrWhiteSpace(isNew) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isNew, out var yn) ? yn : null,
            WarrantyMonths = form.TryGetValue("WarrantyMonths", out var warranty) &&
                            !string.IsNullOrWhiteSpace(warranty) &&
                            byte.TryParse(warranty, out var wm) ? wm : null,
            CPU = form.TryGetValue("CPU", out var cpu) && !string.IsNullOrWhiteSpace(cpu) ? cpu.ToString() : null,
            RamSize = form.TryGetValue("RamSize", out var ramSize) &&
                     !string.IsNullOrWhiteSpace(ramSize) &&
                     Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.RamSize>(ramSize, out var rs) ? rs : null,
            IsSSD = form.TryGetValue("IsSSD", out var isSSD) &&
                   !string.IsNullOrWhiteSpace(isSSD) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isSSD, out var ssd) ? ssd : null,
            StorageCapacity = form.TryGetValue("StorageCapacity", out var storage) &&
                             !string.IsNullOrWhiteSpace(storage) &&
                             Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(storage, out var sc) ? sc : null,
            GraphicsCard = form.TryGetValue("GraphicsCard", out var gpu) && !string.IsNullOrWhiteSpace(gpu) ? gpu.ToString() : null,
            UsbPorts = form.TryGetValue("UsbPorts", out var usb) &&
                      !string.IsNullOrWhiteSpace(usb) &&
                      byte.TryParse(usb, out var up) ? up : null,
            HdmiPorts = form.TryGetValue("HdmiPorts", out var hdmi) &&
                       !string.IsNullOrWhiteSpace(hdmi) &&
                       byte.TryParse(hdmi, out var hp) ? hp : null
        };
    }

    public static void UpdateAttributes(Ad ad, ComputerAdDto dto)
    {
        if (ad is Computer computer)
        {
            if (dto.IsNew.HasValue)
                computer.IsNew = dto.IsNew;
            if (dto.WarrantyMonths.HasValue)
                computer.WarrantyMonths = dto.WarrantyMonths;
            if (!string.IsNullOrEmpty(dto.CPU))
                computer.CPU = dto.CPU;
            if (dto.RamSize.HasValue)
                computer.RamSize = dto.RamSize;
            if (dto.IsSSD.HasValue)
                computer.IsSSD = dto.IsSSD;
            if (dto.StorageCapacity.HasValue)
                computer.StorageCapacity = dto.StorageCapacity;
            if (!string.IsNullOrEmpty(dto.GraphicsCard))
                computer.GraphicsCard = dto.GraphicsCard;
            if (dto.UsbPorts.HasValue)
                computer.UsbPorts = dto.UsbPorts;
            if (dto.HdmiPorts.HasValue)
                computer.HdmiPorts = dto.HdmiPorts;
        }
    }
}
