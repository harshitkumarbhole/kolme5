namespace Kolme.API.Data.Entities;

public class EmployeeModuleAssignment
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public int ModuleId { get; set; }
    public Module? Module { get; set; }
}
