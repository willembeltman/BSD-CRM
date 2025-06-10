namespace BSD.Business.Converters;

public static class ProductPriceConverter
{
    public static BSD.Shared.Dtos.ProductPrice ToDto(this BSD.Data.Entities.ProductPrice item)
    {
        var newItem = new BSD.Shared.Dtos.ProductPrice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static BSD.Data.Entities.ProductPrice ToEntity(this BSD.Shared.Dtos.ProductPrice item)
    {
        var newItem = new BSD.Data.Entities.ProductPrice();
        item.CopyTo(newItem);
        return newItem;
    }
    public static bool CopyTo(this BSD.Shared.Dtos.ProductPrice source, BSD.Data.Entities.ProductPrice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ProductId != source.ProductId) { dest.ProductId = source.ProductId; dirty = true; }
        if (dest.TaxRateId != source.TaxRateId) { dest.TaxRateId = source.TaxRateId; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        return dirty;
    }
    public static bool CopyTo(this BSD.Data.Entities.ProductPrice source, BSD.Shared.Dtos.ProductPrice dest)
    {
        var dirty = false;
        if (dest.Id != source.Id) { dest.Id = source.Id; dirty = true; }
        if (dest.ProductId != source.ProductId) { dest.ProductId = source.ProductId; dirty = true; }
        if (dest.TaxRateId != source.TaxRateId) { dest.TaxRateId = source.TaxRateId; dirty = true; }
        if (dest.Price != source.Price) { dest.Price = source.Price; dirty = true; }
        return dirty;
    }
}