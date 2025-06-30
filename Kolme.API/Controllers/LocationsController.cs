namespace Kolme.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly KolmeDbContext _db;
    private readonly ILogger<LocationsController> _logger;

    public LocationsController(KolmeDbContext db, ILogger<LocationsController> logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var data = await _db.Locations.ToListAsync();
            return Ok(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting locations");
            return StatusCode(500, "Internal server error");
        }
    }
}
