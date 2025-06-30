namespace Kolme.API.Data.Entities;

public class Role
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<EmployeeRoleAssignment> EmployeeAssignments { get; set; } = new List<EmployeeRoleAssignment>();
}
