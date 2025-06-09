using Storage.Shared.Interfaces;

namespace Storage.Proxy
{
    public interface IProxyService
    {
        Task<bool> Delete(IStorageFile storageFile, bool throwIfNotFound = true);
        Task<bool> Exists(IStorageFile storageFile);
        Task<string> GetUrl(IStorageFile storageFile);
        Task<Stream> Open(IStorageFile storageFile);
        Task Save(IStorageFile storageFile, string fileName, string mimeType, Stream stream, bool allowOverwrite = true);
    }
}