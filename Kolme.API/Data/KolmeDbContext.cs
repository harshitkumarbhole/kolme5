namespace Kolme.API.Data;

public class KolmeDbContext : DbContext
{
    public KolmeDbContext(DbContextOptions<KolmeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Entities.Employee> Employees => Set<Entities.Employee>();
    public DbSet<Entities.Department> Departments => Set<Entities.Department>();
    public DbSet<Entities.JobTitle> JobTitles => Set<Entities.JobTitle>();
    public DbSet<Entities.Location> Locations => Set<Entities.Location>();
    public DbSet<Entities.Division> Divisions => Set<Entities.Division>();
    public DbSet<Entities.Module> Modules => Set<Entities.Module>();
    public DbSet<Entities.Role> Roles => Set<Entities.Role>();
    public DbSet<Entities.Document> Documents => Set<Entities.Document>();
    public DbSet<Entities.User> Users => Set<Entities.User>();
    public DbSet<Entities.EmployeeRoleAssignment> EmployeeRoleAssignments => Set<Entities.EmployeeRoleAssignment>();
    public DbSet<Entities.EmployeeModuleAssignment> EmployeeModuleAssignments => Set<Entities.EmployeeModuleAssignment>();
    public DbSet<Entities.EmployeeLocationAssignment> EmployeeLocationAssignments => Set<Entities.EmployeeLocationAssignment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Entities.Department>().HasData(
            new Entities.Department { Id = 1, Name = "HR" },
            new Entities.Department { Id = 2, Name = "Finance" },
            new Entities.Department { Id = 3, Name = "Engineering" },
            new Entities.Department { Id = 4, Name = "Sales" },
            new Entities.Department { Id = 5, Name = "Marketing" }
        );

        modelBuilder.Entity<Entities.JobTitle>().HasData(
            new Entities.JobTitle { Id = 1, Name = "Manager" },
            new Entities.JobTitle { Id = 2, Name = "Engineer" },
            new Entities.JobTitle { Id = 3, Name = "Analyst" },
            new Entities.JobTitle { Id = 4, Name = "Designer" },
            new Entities.JobTitle { Id = 5, Name = "Consultant" }
        );

        modelBuilder.Entity<Entities.Location>().HasData(
            new Entities.Location { Id = 1, Name = "Bengaluru" },
            new Entities.Location { Id = 2, Name = "Mumbai" },
            new Entities.Location { Id = 3, Name = "Delhi" },
            new Entities.Location { Id = 4, Name = "Chennai" },
            new Entities.Location { Id = 5, Name = "Hyderabad" }
        );

        modelBuilder.Entity<Entities.Division>().HasData(
            new Entities.Division { Id = 1, Name = "DivisionA" },
            new Entities.Division { Id = 2, Name = "DivisionB" },
            new Entities.Division { Id = 3, Name = "DivisionC" },
            new Entities.Division { Id = 4, Name = "DivisionD" },
            new Entities.Division { Id = 5, Name = "DivisionE" }
        );

        modelBuilder.Entity<Entities.Module>().HasData(
            new Entities.Module { Id = 1, Name = "ModuleA" },
            new Entities.Module { Id = 2, Name = "ModuleB" },
            new Entities.Module { Id = 3, Name = "ModuleC" },
            new Entities.Module { Id = 4, Name = "ModuleD" },
            new Entities.Module { Id = 5, Name = "ModuleE" }
        );

        modelBuilder.Entity<Entities.Role>().HasData(
            new Entities.Role { Id = 1, Name = "Admin" },
            new Entities.Role { Id = 2, Name = "User" },
            new Entities.Role { Id = 3, Name = "Manager" },
            new Entities.Role { Id = 4, Name = "Staff" },
            new Entities.Role { Id = 5, Name = "Guest" }
        );

        modelBuilder.Entity<Entities.Document>().HasData(
            new Entities.Document { Id = 1, Title = "Document1" },
            new Entities.Document { Id = 2, Title = "Document2" },
            new Entities.Document { Id = 3, Title = "Document3" }
        );


        var user1 = new Entities.User
        {
            Id = 1,
            Username = "user1",
            PasswordHash = "AT/G9IR6v8qQIPHEVWXttkWvp7pe6CyX/57XTL+VWg3oTNnA6D9kfQCvy/f66zTBNg=="
        };

        var user2 = new Entities.User
        {
            Id = 2,
            Username = "user2",
            PasswordHash = "AafM2hH9uXftvNzus2JY3NhbS5YQS3m0OwZqSGlcoFRmUw7fWzG0la7DrVhlLQuZgQ=="
        };


        modelBuilder.Entity<Entities.User>().HasData(user1, user2);

        var emp1 = new Entities.Employee
        {
            Id = 1,
            Code = "E001",
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Phone = "1234567890",
            DepartmentId = 1,
            JobTitleId = 1,
            LocationId = 1,
            DivisionId = 1,
            Gender = "Male",
            StartDate = new DateTime(2020, 1, 1),
            Status = "Active"
        };

        var emp2 = new Entities.Employee
        {
            Id = 2,
            Code = "E002",
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane@example.com",
            Phone = "0987654321",
            DepartmentId = 2,
            JobTitleId = 2,
            LocationId = 2,
            DivisionId = 2,
            ReportingManagerId = 1,
            Gender = "Female",
            StartDate = new DateTime(2021, 6, 1),
            Status = "Active"
        };

        modelBuilder.Entity<Entities.Employee>().HasData(emp1, emp2);

        modelBuilder.Entity<Entities.EmployeeRoleAssignment>().HasData(
            new Entities.EmployeeRoleAssignment { Id = 1, EmployeeId = 1, RoleId = 1 },
            new Entities.EmployeeRoleAssignment { Id = 2, EmployeeId = 2, RoleId = 2 }
        );

        modelBuilder.Entity<Entities.EmployeeModuleAssignment>().HasData(
            new Entities.EmployeeModuleAssignment { Id = 1, EmployeeId = 1, ModuleId = 1 },
            new Entities.EmployeeModuleAssignment { Id = 2, EmployeeId = 2, ModuleId = 2 }
        );

        modelBuilder.Entity<Entities.EmployeeLocationAssignment>().HasData(
            new Entities.EmployeeLocationAssignment { Id = 1, EmployeeId = 1, LocationId = 1 },
            new Entities.EmployeeLocationAssignment { Id = 2, EmployeeId = 2, LocationId = 2 }
        );
    }
}
