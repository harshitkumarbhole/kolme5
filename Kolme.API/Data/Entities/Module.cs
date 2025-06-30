namespace Kolme.API.Data.Entities;

public class Module
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<EmployeeModuleAssignment> EmployeeAssignments { get; set; } = new List<EmployeeModuleAssignment>();
}
