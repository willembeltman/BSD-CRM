using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface ISettingService
{
    SettingCreateResponse Create(SettingCreateRequest request);
    SettingDeleteResponse Delete(SettingDeleteRequest request);
    SettingListResponse List(SettingListRequest request);
    SettingReadResponse Read(SettingReadRequest request);
    SettingUpdateResponse Update(SettingUpdateRequest request);
}