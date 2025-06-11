using BSD.Business.Interfaces;
using BSD.Data.Entities;

namespace BSD.Business.Services;

public class ForgetPasswordService : IForgotPasswordService
{
    public async Task Handle(User dbuser)
    {
        throw new NotImplementedException();
    }
}