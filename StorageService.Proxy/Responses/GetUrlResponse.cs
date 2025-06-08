namespace StorageServer.Proxy.Responses;

#nullable disable

public class GetUrlResponse : Response
{
    public string BaseFolder { get; set; }
    public string Folder { get; set; }
    public string FileName { get; set; }
    public string Token { get; set; }
    public string Url => $"{BaseFolder}/{Folder}/{FileName}?token={Token}";
    public string MimeType { get; set; }
}