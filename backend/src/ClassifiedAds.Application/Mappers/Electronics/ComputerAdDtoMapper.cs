using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Electronics;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;

namespace ClassifiedAds.Application.Mappers;

public static class ComputerAdDtoMapper
{
    public static Computer MapToEntity(
        CreateComputerAdDto dto,
        string slug,
        Guid userId,
        List<string> categoriesSlugsArabic, List<string> categoriesSlugsKurdish,
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
            Category = new Category { CategoriesSlugsArabic = categoriesSlugsArabic, CategoriesSlugsKurdish = categoriesSlugsKurdish },
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

    public static GetComputerAdDto MapToDto(Computer entity)
    {
        return new GetComputerAdDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Price = new DTOs.Common.PriceResponseDto { Value = entity.Price.Value, IsDollar = entity.Price.IsDollar, ShowingPrice = entity.Price.ShowingPrice },
            LocationAd = new DTOs.Common.LocationAdResponseDto { LocationIds = entity.LocationAd.LocationIds, FullAddressArabic = entity.LocationAd.FullAddressArabic, FullAddressKurdish = entity.LocationAd.FullAddressKurdish, Street = entity.LocationAd.Street },
            Images = entity.Images.Select(img => new DTOs.Common.AdImageDto { ImageId = img.ImageId, ImageUrl = img.ImageUrl, Order = img.Order }).ToList(),
            Status = (int)entity.Status,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            ImageCount = entity.ImageCount,
            ViewsCount = entity.ViewsCount,
            Priority = entity.Priority,
            Slug = entity.Slug,
            Category = new DTOs.Common.CategoryResponseDto { CategoriesSlugsArabic = entity.Category.CategoriesSlugsArabic, CategoriesSlugsKurdish = entity.Category.CategoriesSlugsKurdish },
            Specs = new ComputerSpecsDto
            {
                IsNew = entity.IsNew,
                WarrantyMonths = entity.WarrantyMonths,
                CPU = entity.CPU,
                RamSize = entity.RamSize,
                IsSSD = entity.IsSSD,
                StorageCapacity = entity.StorageCapacity,
                GraphicsCard = entity.GraphicsCard,
                UsbPorts = entity.UsbPorts,
                HdmiPorts = entity.HdmiPorts
            }
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
            IsNew = ParseEnum<Domain.Common.Enums.YesNo>(form, "IsNew"),
            WarrantyMonths = ParseByte(form, "WarrantyMonths"),
            CPU = ParseString(form, "CPU"),
            RamSize = ParseEnum<Domain.Entities.Ads.Electronics.Enums.RamSize>(form, "RamSize"),
            IsSSD = ParseEnum<Domain.Common.Enums.YesNo>(form, "IsSSD"),
            StorageCapacity = ParseEnum<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(form, "StorageCapacity"),
            GraphicsCard = ParseString(form, "GraphicsCard"),
            UsbPorts = ParseByte(form, "UsbPorts"),
            HdmiPorts = ParseByte(form, "HdmiPorts")
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
            IsNew = ParseEnum<Domain.Common.Enums.YesNo>(form, "IsNew"),
            WarrantyMonths = ParseByte(form, "WarrantyMonths"),
            CPU = ParseString(form, "CPU"),
            RamSize = ParseEnum<Domain.Entities.Ads.Electronics.Enums.RamSize>(form, "RamSize"),
            IsSSD = ParseEnum<Domain.Common.Enums.YesNo>(form, "IsSSD"),
            StorageCapacity = ParseEnum<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(form, "StorageCapacity"),
            GraphicsCard = ParseString(form, "GraphicsCard"),
            UsbPorts = ParseByte(form, "UsbPorts"),
            HdmiPorts = ParseByte(form, "HdmiPorts")
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
