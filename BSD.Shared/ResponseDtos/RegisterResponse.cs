﻿namespace BSD.Shared.ResponseDtos;

public class RegisterResponse : BaseResponse
{
    public bool ErrorEmailNotValid { get; set; }
    public bool ErrorEmailInUse { get; set; }
    public bool ErrorUsernameInUse { get; set; }
    public bool ErrorUsernameEmpty { get; set; }
    public bool ErrorPasswordEmpty { get; set; }
    public bool ErrorPhoneNumberEmpty { get; set; }
    public bool ErrorCouldNotCreateUser { get; set; }
    public bool ErrorCouldNotGetDevice { get; set; }
    public bool ErrorCouldNotCreateBearer { get; set; }
}
