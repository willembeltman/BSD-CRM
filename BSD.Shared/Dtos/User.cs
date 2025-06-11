namespace BSD.Shared.Dtos;

public class User
{
    public string Id { get; set; } = string.Empty;
    public long? CurrentCompanyId { get; set; }
    public string? CurrentCompanyName { get; set; }
    public string? PasswordHash { get; set; }
    public bool LockedOut { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}