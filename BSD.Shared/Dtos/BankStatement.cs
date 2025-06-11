using BSD.Shared.Enums;

namespace BSD.Shared.Dtos;

public class BankStatement
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string VolgNr { get; set; } = string.Empty;
    public CreditTypeEnum CreditType { get; set; }
    public BankEnum? Bank { get; set; }
    public string EigenRekeningNumber { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public double Price { get; set; }
    public string TegenRekeningNumber { get; set; } = string.Empty;
    public string TegenName { get; set; } = string.Empty;
    public string? Description1 { get; set; }
    public string? Description2 { get; set; }
    public string? Description3 { get; set; }
    public double Saldo { get; set; }
    public double KleineOndernemersRegeling { get; set; }
    public bool IsHuur { get; set; }
    public bool IsBelastingBTW { get; set; }
    public bool IsBelasting { get; set; }
    public string Description { get; set; } = string.Empty;
    public double CreditRatePrice { get; set; }
    public double DebitRatePrice { get; set; }
}