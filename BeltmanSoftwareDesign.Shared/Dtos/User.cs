namespace BeltmanSoftwareDesign.Shared.Dtos;

public class User
{
    public string id { get; set; } = string.Empty;

    public string userName { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string phoneNumber { get; set; } = string.Empty;
    public long? currentCompanyId { get; set; }
}