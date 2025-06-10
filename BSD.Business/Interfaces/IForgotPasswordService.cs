using BSD.Data.Entities;

namespace BSD.Business.Interfaces;

public interface IForgotPasswordService
{
    void Handle(User dbuser);
}