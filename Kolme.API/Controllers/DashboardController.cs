namespace Kolme.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly KolmeDbContext _db;
    private readonly ILogger<DashboardController> _logger;

    public DashboardController(KolmeDbContext db, ILogger<DashboardController> logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet("counts")]
    public async Task<IActionResult> GetCounts()
    {
        try
        {
            var employeeCount = await _db.Employees.CountAsync();
            var departmentCount = await _db.Departments.CountAsync();
            // Pending leaves not implemented, return 0
            var pendingLeaves = 0;
            return Ok(new { employees = employeeCount, departments = departmentCount, pendingLeaves });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting dashboard counts");
            return StatusCode(500, "Internal server error");
        }
    }
}
