using BSD.Business.CrudInterfaces;
using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace BSD.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EmailController(IEmailService email) : ControllerBase
{
    [HttpPost]
    public EmailCreateResponse Create(EmailCreateRequest request)
        => email.Create(request);

    [HttpPost]
    public EmailReadResponse Read(EmailReadRequest request)
        => email.Read(request);

    [HttpPost]
    public EmailUpdateResponse Update(EmailUpdateRequest request)
        => email.Update(request);

    [HttpPost]
    public EmailDeleteResponse Delete(EmailDeleteRequest request)
        => email.Delete(request);

    [HttpPost]
    public EmailListResponse List(EmailListRequest request)
        => email.List(request);
}
