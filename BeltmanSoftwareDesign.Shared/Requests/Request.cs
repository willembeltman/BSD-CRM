using CodeGenerator.Library.Attributes;

namespace BeltmanSoftwareDesign.Shared.Requests;

[TsHidden]
public class Request
{
    public string? BearerId { get; set; }
    public long? CurrentCompanyId { get; set; }
}
