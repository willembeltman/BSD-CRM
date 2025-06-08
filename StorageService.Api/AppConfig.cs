using StorageServer.Shared.Dtos;
using System.Text;

namespace StorageServer.Proxy;

#nullable disable

public class AppConfig
{
    public string SuperSecretKey { get; set; }
    public Credential[] Credentials { get; set; }

    private byte[] _SuperSecretKeyArray { get; set; }
    public byte[] SuperSecretKeyArray
    {
        get
        {
            if (_SuperSecretKeyArray == null)
                _SuperSecretKeyArray = Encoding.ASCII.GetBytes(SuperSecretKey);
            return _SuperSecretKeyArray;
        }
    }
}