using System;

namespace BSD.Shared.Dtos;

public class Email
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public DateTime? EmailDate { get; set; }
    public string? EmailFrom { get; set; }
    public string? EmailTo { get; set; }
    public int EmailIndex { get; set; }
    public string? EmailSubject { get; set; }
    public string? EmailHtmlBody { get; set; }
    public string? EmailTextBody { get; set; }
    public bool Hidden { get; set; }
}