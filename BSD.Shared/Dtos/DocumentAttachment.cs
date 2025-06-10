using System;


namespace BSD.Shared.Dtos;

public class DocumentAttachment
{
    public long Id { get; set; }
    public long? DocumentId { get; set; }
    public string? Description { get; set; }
}