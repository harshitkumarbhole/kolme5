namespace Kolme.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly KolmeDbContext _db;
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(KolmeDbContext db, ILogger<EmployeesController> logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees([FromQuery] string? search)
    {
        try
        {
            var query = _db.Employees.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e => e.Code.Contains(search) || (e.FirstName + " " + e.LastName).Contains(search));
            }
            var employees = await query.ToListAsync();
            return Ok(employees);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting employees");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] DTOs.CreateEmployeeDTO dto)
    {
        try
        {
            if (dto.EndDate.HasValue && dto.StartDate > dto.EndDate.Value)
            {
                ModelState.AddModelError("EndDate", "EndDate must be after StartDate");
                return ValidationProblem(ModelState);
            }

            var employee = new Data.Entities.Employee
            {
                Code = dto.Code,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                DepartmentId = dto.DepartmentId,
                JobTitleId = dto.JobTitleId,
                LocationId = dto.LocationId,
                DivisionId = dto.DivisionId,
                ReportingManagerId = dto.ReportingManagerId,
                Gender = dto.Gender,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Status = dto.Status
            };
            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating employee");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            var employee = await _db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting employee");
            return StatusCode(500, "Internal server error");
        }
    }
}
