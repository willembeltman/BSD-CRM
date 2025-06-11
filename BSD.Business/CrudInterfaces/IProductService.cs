using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IProductService
{
    ProductCreateResponse Create(ProductCreateRequest request);
    ProductDeleteResponse Delete(ProductDeleteRequest request);
    ProductListResponse List(ProductListRequest request);
    ProductReadResponse Read(ProductReadRequest request);
    ProductUpdateResponse Update(ProductUpdateRequest request);
}