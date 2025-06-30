namespace Kolme.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly KolmeDbContext _db;
    private readonly ILogger<RolesController> _logger;

    public RolesController(KolmeDbContext db, ILogger<RolesController> logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var data = await _db.Roles.ToListAsync();
            return Ok(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting roles");
            return StatusCode(500, "Internal server error");
        }
    }
}
