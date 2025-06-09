namespace BeltmanSoftwareDesign.Shared.Interfaces;

public interface IProxySettingsService
{
    string GetPassword();
    string GetServerUrl();
    string GetUserName();
}