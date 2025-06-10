using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.Interfaces;

public interface IEmailService
{
    EmailCreateResponse Create(EmailCreateRequest request);
    EmailDeleteResponse Delete(EmailDeleteRequest request);
    EmailListResponse List(EmailListRequest request);
    EmailReadResponse Read(EmailReadRequest request);
    EmailUpdateResponse Update(EmailUpdateRequest request);
}