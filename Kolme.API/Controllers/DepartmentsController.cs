namespace Kolme.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly KolmeDbContext _db;
    private readonly ILogger<DepartmentsController> _logger;

    public DepartmentsController(KolmeDbContext db, ILogger<DepartmentsController> logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var data = await _db.Departments.ToListAsync();
            return Ok(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting departments");
            return StatusCode(500, "Internal server error");
        }
    }
}
