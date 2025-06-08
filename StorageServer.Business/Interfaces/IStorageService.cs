using StorageServer.Proxy.Requests;
using StorageServer.Proxy.Responses;

namespace StorageServer.Business.Interfaces
{
    public interface IStorageService
    {
        DeleteResponse Delete(DeleteRequest model);
        Task<DeleteResponse> DeleteAsync(DeleteRequest model);
        DownloadResponse Download(DownloadRequest model);
        Task<DownloadResponse> DownloadAsync(DownloadRequest model);
        ExistsResponse Exists(ExistsRequest model);
        Task<ExistsResponse> ExistsAsync(ExistsRequest model);
        GetUrlResponse GetUrl(GetUrlRequest model);
        Task<GetUrlResponse> GetUrlAsync(GetUrlRequest model);
        OpenResponse Open(OpenRequest model);
        Task<OpenResponse> OpenAsync(OpenRequest model);
        SaveResponse Save(SaveRequest model, Stream inputStream);
        Task<SaveResponse> SaveAsync(SaveRequest model, Stream inputStream);
    }
}