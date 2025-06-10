using System;


namespace BSD.Shared.Dtos;

public class CompanyUser
{
    public long Id { get; set; }
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string? UserId { get; set; }
    public bool Eigenaar { get; set; }
    public bool Admin { get; set; }
    public bool Actief { get; set; }
}