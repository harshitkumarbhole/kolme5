namespace Kolme.API.Data.Entities;

public class Employee
{
    public int Id { get; set; }
    [Required]
    public string Code { get; set; } = string.Empty;
    [Required]
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Phone { get; set; } = string.Empty;

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    public int JobTitleId { get; set; }
    public JobTitle? JobTitle { get; set; }

    public int LocationId { get; set; }
    public Location? Location { get; set; }

    public int DivisionId { get; set; }
    public Division? Division { get; set; }

    public int? ReportingManagerId { get; set; }
    public Employee? ReportingManager { get; set; }

    [Required]
    public string Gender { get; set; } = string.Empty;
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Required]
    public string Status { get; set; } = string.Empty;

    public ICollection<EmployeeRoleAssignment> RoleAssignments { get; set; } = new List<EmployeeRoleAssignment>();
    public ICollection<EmployeeModuleAssignment> ModuleAssignments { get; set; } = new List<EmployeeModuleAssignment>();
    public ICollection<EmployeeLocationAssignment> LocationAssignments { get; set; } = new List<EmployeeLocationAssignment>();
}
