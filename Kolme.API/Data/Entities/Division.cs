namespace Kolme.API.Data.Entities;

public class Division
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
