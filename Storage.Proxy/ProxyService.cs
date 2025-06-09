using Storage.Shared.Interfaces;

namespace Storage.Proxy;

public class ProxyService : IProxyService
{
    public async Task<string> GetUrl(IStorageFile storageFile)
    {
        return await storageFile.GetUrl();
    }
    public async Task<bool> Exists(IStorageFile storageFile)
    {
        return await storageFile.Exists();
    }
    public async Task<Stream> Open(IStorageFile storageFile)
    {
        return await storageFile.Open();
    }
    public async Task Save(IStorageFile storageFile, string fileName, string mimeType, Stream stream, bool allowOverwrite = true)
    {
        await storageFile.Save(fileName, mimeType, stream, allowOverwrite);
    }
    public async Task<bool> Delete(IStorageFile storageFile, bool throwIfNotFound = true)
    {
        return await storageFile.Delete(throwIfNotFound);
    }
}
