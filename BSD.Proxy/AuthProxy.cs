using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace BSD.Proxy;

public class AuthProxy(HttpClient httpClient)
{
    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Auth/Login", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<LoginResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<RegisterResponse> Register(RegisterRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Auth/Register", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<RegisterResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }

    public async Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/Auth/ForgotPassword", request);
        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadFromJsonAsync<ForgotPasswordResponse>()
            ?? throw new Exception("Could not cast response data");
        return responseData;
    }
}
