namespace BeltmanSoftwareDesign.Shared.Responses
{
    public class LoginResponse : Response
    {
        public bool ErrorEmailNotValid { get; set; }
        public bool AuthenticationError { get; set; }
    }
}
