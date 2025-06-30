namespace Kolme.API.DTOs;

public class CreateEmployeeDTO
{
    public string Code { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public int JobTitleId { get; set; }
    public int LocationId { get; set; }
    public int DivisionId { get; set; }
    public int? ReportingManagerId { get; set; }
    public string Gender { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
}
