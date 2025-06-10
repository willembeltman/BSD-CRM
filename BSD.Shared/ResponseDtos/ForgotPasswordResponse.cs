namespace BSD.Shared.ResponseDtos;

public class ForgotPasswordResponse : BaseResponse
{
    public bool ErrorEmailNotValid { get; set; }
    public bool ErrorCouldNotGetDevice { get; set; }
    public bool ErrorCouldNotGetIp { get; set; }
    public bool ErrorCouldNotCreateBearer { get; set; }
}