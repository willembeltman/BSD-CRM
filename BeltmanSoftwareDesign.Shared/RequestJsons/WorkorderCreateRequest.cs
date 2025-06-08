using BeltmanSoftwareDesign.Shared.Jsons;

namespace BeltmanSoftwareDesign.Shared.RequestJsons;

#nullable disable

public class WorkorderCreateRequest : Request
{
    public Workorder Workorder { get; set; }
}
