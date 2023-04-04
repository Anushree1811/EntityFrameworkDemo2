namespace EntityFrameworkDemo2.Models;

public class BankAccount
{
    public Guid Id { get; set; }

    public string? BankName { get; set; }

    public string? AccountId { get; set; }

    public string? AccountType { get; set; }
}
