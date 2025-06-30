namespace Kolme.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobTitlesController : ControllerBase
{
    private readonly KolmeDbContext _db;
    private readonly ILogger<JobTitlesController> _logger;

    public JobTitlesController(KolmeDbContext db, ILogger<JobTitlesController> logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var data = await _db.JobTitles.ToListAsync();
            return Ok(data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting job titles");
            return StatusCode(500, "Internal server error");
        }
    }
}
