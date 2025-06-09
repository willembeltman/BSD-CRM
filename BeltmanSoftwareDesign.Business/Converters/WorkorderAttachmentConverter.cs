using StorageServer.Proxy;

namespace BeltmanSoftwareDesign.Data.Converters
{
    public class WorkorderAttachmentConverter
    {
        public async Task<Shared.Dtos.WorkorderAttachment> Create(Entities.WorkorderAttachment a)
        {
            return new Shared.Dtos.WorkorderAttachment()
            {
                Id = a.Id,
                WorkorderId = a.WorkorderId,
                FileUrl = await a.GetUrl() ?? throw new ArgumentNullException(nameof(a)),
            };
        }
    }
}