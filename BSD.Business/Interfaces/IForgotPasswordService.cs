using BSD.Data.Entities;

namespace BSD.Business.Interfaces;

public interface IForgotPasswordService
{
    Task Handle(User dbuser);
}