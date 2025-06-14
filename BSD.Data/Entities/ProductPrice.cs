﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSD.Data.Entities;

public class ProductPrice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public long? TaxRateId { get; set; }
    public virtual TaxRate? TaxRate { get; set; }

    public double Price { get; set; }



    //[NotMapped]
    //public double Tax => Price * TaxRate.Percentage / 100;
    //[NotMapped]
    //public double ConsumentenRatePrice => Price + Tax;

    //public override string ToString()
    //    => $"{Expense.Date.ToShortDateString()} €{ConsumentenRatePrice.ToString("F2")} {Expense.Supplier}: {Expense.Description}";

}
