using CodeGenerator.Shared.Attributes;

namespace BSD.Shared.Requests;

[TsHidden]
public class Request
{
    public string? BearerId { get; set; }
    public long? CurrentCompanyId { get; set; }
}
