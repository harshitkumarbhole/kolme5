namespace Kolme.API.Data.Entities;

public class EmployeeRoleAssignment
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public int RoleId { get; set; }
    public Role? Role { get; set; }
}
