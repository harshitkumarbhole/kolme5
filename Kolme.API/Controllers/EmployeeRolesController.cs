namespace Kolme.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeRolesController : ControllerBase
{
    private readonly KolmeDbContext _db;
    private readonly ILogger<EmployeeRolesController> _logger;

    public EmployeeRolesController(KolmeDbContext db, ILogger<EmployeeRolesController> logger)
    {
        _db = db;
        _logger = logger;
    }

    public class AssignmentRequest
    {
        public int EmployeeId { get; set; }
        public List<int> RoleIds { get; set; } = new();
        public List<int> ModuleIds { get; set; } = new();
        public List<int> LocationIds { get; set; } = new();
    }

    [HttpPost("assign")]
    public async Task<IActionResult> Assign([FromBody] AssignmentRequest request)
    {
        try
        {
            var employeeExists = await _db.Employees.AnyAsync(e => e.Id == request.EmployeeId);
            if (!employeeExists)
            {
                return NotFound();
            }

            foreach (var roleId in request.RoleIds.Distinct())
            {
                if (!await _db.EmployeeRoleAssignments.AnyAsync(a => a.EmployeeId == request.EmployeeId && a.RoleId == roleId))
                {
                    _db.EmployeeRoleAssignments.Add(new Data.Entities.EmployeeRoleAssignment { EmployeeId = request.EmployeeId, RoleId = roleId });
                }
            }

            foreach (var moduleId in request.ModuleIds.Distinct())
            {
                if (!await _db.EmployeeModuleAssignments.AnyAsync(a => a.EmployeeId == request.EmployeeId && a.ModuleId == moduleId))
                {
                    _db.EmployeeModuleAssignments.Add(new Data.Entities.EmployeeModuleAssignment { EmployeeId = request.EmployeeId, ModuleId = moduleId });
                }
            }

            foreach (var locationId in request.LocationIds.Distinct())
            {
                if (!await _db.EmployeeLocationAssignments.AnyAsync(a => a.EmployeeId == request.EmployeeId && a.LocationId == locationId))
                {
                    _db.EmployeeLocationAssignments.Add(new Data.Entities.EmployeeLocationAssignment { EmployeeId = request.EmployeeId, LocationId = locationId });
                }
            }

            await _db.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error assigning roles/modules/locations");
            return StatusCode(500, "Internal server error");
        }
    }
}
