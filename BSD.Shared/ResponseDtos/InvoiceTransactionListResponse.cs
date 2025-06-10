using BSD.Shared.Dtos;

namespace BSD.Shared.ResponseDtos;

public class InvoiceTransactionListResponse : BaseResponse
{
    public InvoiceTransaction[] InvoiceTransactions { get; set; } = [];
}