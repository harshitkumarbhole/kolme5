namespace Kolme.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DivisionsController : ControllerBase
{
    private readonly KolmeDbContext _db;
    private readonly ILogger<DivisionsController> _logger;

    public DivisionsController(KolmeDbContext db, ILogger<DivisionsController> logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var data = await _db.Divisions.ToListAsync();
            return Ok(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting divisions");
            return StatusCode(500, "Internal server error");
        }
    }
}
