namespace BSD.Shared.ResponseDtos
{
    public class LoginResponse : BaseResponse
    {
        public bool ErrorEmailNotValid { get; set; }
        public bool AuthenticationError { get; set; }
    }
}
