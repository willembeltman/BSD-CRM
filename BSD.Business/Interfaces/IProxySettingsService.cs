namespace BSD.Business.Interfaces;

public interface IProxySettingsService
{
    string GetPassword();
    string GetServerUrl();
    string GetUserName();
}