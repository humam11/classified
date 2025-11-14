using ClassifiedAds.Domain.Entities.PostgreSQL.Enums;

namespace ClassifiedAds.Application.DTOs.Users;

public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public LocationSource LocationSource { get; set; }
    public ushort? LocationId { get; set; }
}
