namespace Kolme.API.Data.Entities;

public class Document
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
}
