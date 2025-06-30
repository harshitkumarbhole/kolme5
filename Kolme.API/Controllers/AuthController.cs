namespace Kolme.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly KolmeDbContext _db;
    private readonly PasswordHasher<Data.Entities.User> _hasher;
    private readonly ILogger<AuthController> _logger;

    public AuthController(KolmeDbContext db, ILogger<AuthController> logger)
    {
        _db = db;
        _logger = logger;
        _hasher = new PasswordHasher<Data.Entities.User>();
    }

    public record LoginRequest(string Username, string Password);

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null)
            {
                return Unauthorized();
            }

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized();
            }

            // return dummy JWT token
            return Ok(new { token = "dummy-token" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during login");
            return StatusCode(500, "Internal server error");
        }
    }
}
