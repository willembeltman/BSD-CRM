namespace BSD.Business.Converters;

public static class BankStatementConverter
{
    public static BSD.Shared.Dtos.BankStatement ToDto(this BSD.Data.Entities.BankStatement item)
    {
        var newItem = new BSD.Shared.Dtos.BankStatement();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.BankStatement ToEntity(this BSD.Shared.Dtos.BankStatement item)
    {
        var newItem = new BSD.Data.Entities.BankStatement();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.BankStatement source, BSD.Data.Entities.BankStatement dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.VolgNr != source.VolgNr) { dest.VolgNr = source.VolgNr; dirty = true; }
        if (dest.CreditType != source.CreditType) { dest.CreditType = source.CreditType; dirty = true; }
        if (dest.Bank != source.Bank) { dest.Bank = source.Bank; dirty = true; }
        if (dest.EigenRekeningNumber != source.EigenRekeningNumber) { dest.EigenRekeningNumber = source.EigenRekeningNumber; dirty = true; }
        if (dest.Currency != source.Currency) { dest.Currency = source.Currency; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        if (dest.TegenRekeningNumber != source.TegenRekeningNumber) { dest.TegenRekeningNumber = source.TegenRekeningNumber; dirty = true; }
        if (dest.TegenName != source.TegenName) { dest.TegenName = source.TegenName; dirty = true; }
        if (dest.Description1 != source.Description1) { dest.Description1 = source.Description1; dirty = true; }
        if (dest.Description2 != source.Description2) { dest.Description2 = source.Description2; dirty = true; }
        if (dest.Description3 != source.Description3) { dest.Description3 = source.Description3; dirty = true; }
        if (dest.Saldo != source.Saldo) { dest.Saldo = source.Saldo; dirty = true; }
        if (dest.KleineOndernemersRegeling != source.KleineOndernemersRegeling) { dest.KleineOndernemersRegeling = source.KleineOndernemersRegeling; dirty = true; }
        if (dest.IsHuur != source.IsHuur) { dest.IsHuur = source.IsHuur; dirty = true; }
        if (dest.IsBelastingBTW != source.IsBelastingBTW) { dest.IsBelastingBTW = source.IsBelastingBTW; dirty = true; }
        if (dest.IsBelasting != source.IsBelasting) { dest.IsBelasting = source.IsBelasting; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.BankStatement source, BSD.Shared.Dtos.BankStatement dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.CompanyId != source.CompanyId) { dest.CompanyId = source.CompanyId; dirty = true; }
        if (dest.CompanyName != source.Company?.Name?.ToString()) { dest.CompanyName = source.Company?.Name?.ToString(); dirty = true; }
        if (dest.VolgNr != source.VolgNr) { dest.VolgNr = source.VolgNr; dirty = true; }
        if (dest.CreditType != source.CreditType) { dest.CreditType = source.CreditType; dirty = true; }
        if (dest.Bank != source.Bank) { dest.Bank = source.Bank; dirty = true; }
        if (dest.EigenRekeningNumber != source.EigenRekeningNumber) { dest.EigenRekeningNumber = source.EigenRekeningNumber; dirty = true; }
        if (dest.Currency != source.Currency) { dest.Currency = source.Currency; dirty = true; }
        if (dest.Date != source.Date) { dest.Date = source.Date; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        if (dest.TegenRekeningNumber != source.TegenRekeningNumber) { dest.TegenRekeningNumber = source.TegenRekeningNumber; dirty = true; }
        if (dest.TegenName != source.TegenName) { dest.TegenName = source.TegenName; dirty = true; }
        if (dest.Description1 != source.Description1) { dest.Description1 = source.Description1; dirty = true; }
        if (dest.Description2 != source.Description2) { dest.Description2 = source.Description2; dirty = true; }
        if (dest.Description3 != source.Description3) { dest.Description3 = source.Description3; dirty = true; }
        if (dest.Saldo != source.Saldo) { dest.Saldo = source.Saldo; dirty = true; }
        if (dest.KleineOndernemersRegeling != source.KleineOndernemersRegeling) { dest.KleineOndernemersRegeling = source.KleineOndernemersRegeling; dirty = true; }
        if (dest.IsHuur != source.IsHuur) { dest.IsHuur = source.IsHuur; dirty = true; }
        if (dest.IsBelastingBTW != source.IsBelastingBTW) { dest.IsBelastingBTW = source.IsBelastingBTW; dirty = true; }
        if (dest.IsBelasting != source.IsBelasting) { dest.IsBelasting = source.IsBelasting; dirty = true; }
        if (dest.Description != source.Description) { dest.Description = source.Description; dirty = true; }
        if (dest.CreditRatePrice != source.CreditRatePrice) { dest.CreditRatePrice = source.CreditRatePrice; dirty = true; }
        if (dest.DebitRatePrice != source.DebitRatePrice) { dest.DebitRatePrice = source.DebitRatePrice; dirty = true; }
        return dirty;
    }
}