using BSD.Shared.RequestDtos;
using BSD.Shared.ResponseDtos;

namespace BSD.Business.CrudInterfaces;

public interface IBankStatementInvoiceService
{
    BankStatementInvoiceCreateResponse Create(BankStatementInvoiceCreateRequest request);
    BankStatementInvoiceDeleteResponse Delete(BankStatementInvoiceDeleteRequest request);
    BankStatementInvoiceListResponse List(BankStatementInvoiceListRequest request);
    BankStatementInvoiceReadResponse Read(BankStatementInvoiceReadRequest request);
    BankStatementInvoiceUpdateResponse Update(BankStatementInvoiceUpdateRequest request);
}