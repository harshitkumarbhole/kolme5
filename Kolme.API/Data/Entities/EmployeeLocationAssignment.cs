namespace Kolme.API.Data.Entities;

public class EmployeeLocationAssignment
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public int LocationId { get; set; }
    public Location? Location { get; set; }
}
