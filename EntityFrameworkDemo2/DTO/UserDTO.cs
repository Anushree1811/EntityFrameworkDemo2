namespace EntityFrameworkDemo2.DTO;

public class UserDTO
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public UserAddressDTO? Address { get; set; }
}
