using StorageServer.Proxy.Actions;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace StorageServer.Proxy;

public static class StorageFileExtentions
{
    public static async Task<string?> GetExternalUrl(this IStorageFile storageFile)
    {
        if (storageFile.Id <= 0)
            throw new ArgumentException(
                $"Cannot use storage file server for entities with Id = 0, this indicates the entity has not been attached to the dbcontext jet.");

        using var httpClient = new HttpClient();
        await AuthenticateHttpClient(httpClient);

        var request = new GetUrlRequest()
        {
            Id = storageFile.Id,
            TypeName = storageFile.GetType().Name,
        };

        using var response = await httpClient.PostAsJsonAsync("https://localhost:7190/Storage/GetExternalUrl", request);
        response.EnsureSuccessStatusCode();

        var getExternalUrlResponse = await response.Content.ReadFromJsonAsync<GetUrlResponse>();
        if (getExternalUrlResponse == null)
            throw new Exception("Could not cast response from file server");
        if (getExternalUrlResponse.Success == false)
            throw new Exception(getExternalUrlResponse.Message);

        return getExternalUrlResponse.Url;
    }
    public static async Task<bool> Exists(this IStorageFile storageFile)
    {
        if (storageFile.Id <= 0)
            throw new ArgumentException(
                $"Cannot use storage file server for entities with Id = 0, this indicates the entity has not been attached to the dbcontext jet.");

        using var httpClient = new HttpClient();
        await AuthenticateHttpClient(httpClient);

        var request = new ExistsRequest()
        {
            Id = storageFile.Id,
            TypeName = storageFile.GetType().Name
        };

        using var responseMessage = await httpClient.PostAsJsonAsync("https://localhost:7190/Storage/GetExternalUrl", request);
        responseMessage.EnsureSuccessStatusCode();

        var response = await responseMessage.Content.ReadFromJsonAsync<ExistsResponse>();
        if (response == null)
            throw new Exception("Could not cast response from file server");
        if (response.Success == false)
            throw new Exception(response.Message);

        return response.Exists;
    }
    public static async Task<Stream> Open(this IStorageFile storageFile)
    {
        if (storageFile.Id <= 0)
            throw new ArgumentException(
                $"Cannot use storage file server for entities with Id = 0, this indicates the entity has not been attached to the dbcontext jet.");

        using var httpClient = new HttpClient();
        await AuthenticateHttpClient(httpClient);

        var request = new DeleteRequest()
        {
            Id = storageFile.Id,
            TypeName = storageFile.GetType().Name,
        };

        using var responseMessage = await httpClient.PostAsJsonAsync("https://localhost:7190/Storage/GetExternalUrl", request);
        responseMessage.EnsureSuccessStatusCode();

        return responseMessage.Content.ReadAsStream();
    }
    public static async Task Save(this IStorageFile storageFile, string fileName, string mimeType, Stream stream, bool allowOverwrite = true)
    {
        if (storageFile.Id <= 0)
            throw new ArgumentException(
                $"Cannot use storage file server for entities with Id = 0, this indicates the entity has not been attached to the dbcontext jet.");
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentException(
                $"Cannot use storage file server for entities without StorageFileName filled.");
        if (string.IsNullOrEmpty(mimeType))
            throw new ArgumentException(
                $"Cannot use storage file server for entities without StorageMimeType filled.");

        using var httpClient = new HttpClient();

        await AuthenticateHttpClient(httpClient);

        var content = new MultipartFormDataContent();
        var saveRequest = new SaveRequest
        {
            Id = storageFile.Id,
            FileName = fileName,
            TypeName = storageFile.GetType().Name,
            MimeType = mimeType,
            AllowOverwrite = allowOverwrite
        };

        // Voeg JSON-velden als string toe
        content.Add(new StringContent(saveRequest.Id.ToString()), nameof(SaveRequest.Id));
        content.Add(new StringContent(saveRequest.FileName), nameof(SaveRequest.FileName));
        content.Add(new StringContent(saveRequest.TypeName), nameof(SaveRequest.TypeName));
        content.Add(new StringContent(saveRequest.MimeType), nameof(SaveRequest.MimeType));
        content.Add(new StringContent(saveRequest.AllowOverwrite ? "true" : "false"), nameof(SaveRequest.AllowOverwrite));

        // Voeg bestand toe
        var fileContent = new StreamContent(stream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
        content.Add(fileContent, "file", fileName);

        using var response2 = await httpClient.PostAsync("https://localhost:7190/Storage/Save", content);
        response2.EnsureSuccessStatusCode();

        var model = await response2.Content.ReadFromJsonAsync<SaveResponse>();
        if (model == null)
            throw new Exception("Could not cast response from file server");
        if (!model.Success)
            throw new Exception(model.Message);
    }
    public static async Task<bool> Delete(this IStorageFile storageFile, bool throwIfNotFound = true)
    {
        if (storageFile.Id <= 0)
            throw new ArgumentException(
                $"Cannot use storage file server for entities with Id = 0, this indicates the entity has not been attached to the dbcontext jet.");

        using var httpClient = new HttpClient();
        await AuthenticateHttpClient(httpClient);

        var request = new DeleteRequest()
        {
            Id = storageFile.Id,
            TypeName = storageFile.GetType().Name,
            ThrowIfNotFound = throwIfNotFound
        };

        using var responseMessage = await httpClient.PostAsJsonAsync("https://localhost:7190/Storage/GetExternalUrl", request);
        responseMessage.EnsureSuccessStatusCode();

        var response = await responseMessage.Content.ReadFromJsonAsync<DeleteResponse>();
        if (response == null)
            throw new Exception("Could not cast response from file server");
        if (response.Success == false)
            throw new Exception(response.Message);

        return response.Deleted;
    }

    private static async Task<string> AuthenticateHttpClient(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri(StorageServerSettings.Config.ServerUrl);

        // Stap 1: Login
        var loginRequest = new LoginRequest
        {
            Username = StorageServerSettings.Config.Credential.UserName,
            Password = StorageServerSettings.Config.Credential.Password
        };

        using var response = await httpClient.PostAsJsonAsync("/Auth/Login", loginRequest);
        response.EnsureSuccessStatusCode();

        var loginResult = await response.Content.ReadFromJsonAsync<LoginResponse>();
        var jwtToken = loginResult?.Token;
        if (jwtToken == null) throw new Exception("Kan geen token ophalen");

        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);


        return jwtToken;
    }
}
