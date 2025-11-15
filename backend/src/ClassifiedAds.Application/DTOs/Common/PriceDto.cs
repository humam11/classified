using System.ComponentModel.DataAnnotations;

namespace ClassifiedAds.Application.DTOs.Common;


public class PriceDto
{

    public decimal Value { get; set; }

    public bool IsDollar { get; set; }
}
