namespace Kolme.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModulesController : ControllerBase
{
    private readonly KolmeDbContext _db;
    private readonly ILogger<ModulesController> _logger;

    public ModulesController(KolmeDbContext db, ILogger<ModulesController> logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var data = await _db.Modules.ToListAsync();
            return Ok(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting modules");
            return StatusCode(500, "Internal server error");
        }
    }
}
