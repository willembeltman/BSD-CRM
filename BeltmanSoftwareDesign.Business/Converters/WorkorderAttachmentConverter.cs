using StorageServer.Proxy;

namespace BeltmanSoftwareDesign.Data.Converters
{
    public class WorkorderAttachmentConverter
    {
        public Shared.Jsons.WorkorderAttachment Create(Entities.WorkorderAttachment a)
        {
            return new Shared.Jsons.WorkorderAttachment()
            {
                id = a.id,
                WorkorderId = a.WorkorderId,
                FileUrl = a.GetExternalUrl()
            };
        }
    }
}