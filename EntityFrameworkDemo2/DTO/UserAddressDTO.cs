namespace EntityFrameworkDemo2.DTO;

public class UserAddressDTO
{
    public Guid Id { get; set; }

    public string AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
}
