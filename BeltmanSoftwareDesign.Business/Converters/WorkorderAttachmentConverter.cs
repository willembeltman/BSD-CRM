using StorageServer.Proxy;

namespace BeltmanSoftwareDesign.Data.Converters
{
    public class WorkorderAttachmentConverter
    {
        public async Task<Shared.Jsons.WorkorderAttachment> Create(Entities.WorkorderAttachment a)
        {
            return new Shared.Jsons.WorkorderAttachment()
            {
                id = a.Id,
                WorkorderId = a.WorkorderId,
                FileUrl = await a.GetUrl() ?? throw new ArgumentNullException(nameof(a)),
            };
        }
    }
}