using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Kolme.API.Data;

#nullable disable

namespace Kolme.API.Migrations
{
    [DbContext(typeof(KolmeDbContext))]
    partial class KolmeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Kolme.API.Data.Entities.Department", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Departments");

                b.HasData(
                    new { Id = 1, Name = "HR" },
                    new { Id = 2, Name = "Finance" },
                    new { Id = 3, Name = "Engineering" },
                    new { Id = 4, Name = "Sales" },
                    new { Id = 5, Name = "Marketing" }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.Division", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Divisions");

                b.HasData(
                    new { Id = 1, Name = "DivisionA" },
                    new { Id = 2, Name = "DivisionB" },
                    new { Id = 3, Name = "DivisionC" },
                    new { Id = 4, Name = "DivisionD" },
                    new { Id = 5, Name = "DivisionE" }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.Document", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Documents");

                b.HasData(
                    new { Id = 1, Title = "Document1" },
                    new { Id = 2, Title = "Document2" },
                    new { Id = 3, Title = "Document3" }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.JobTitle", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("JobTitles");

                b.HasData(
                    new { Id = 1, Name = "Manager" },
                    new { Id = 2, Name = "Engineer" },
                    new { Id = 3, Name = "Analyst" },
                    new { Id = 4, Name = "Designer" },
                    new { Id = 5, Name = "Consultant" }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.Location", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Locations");

                b.HasData(
                    new { Id = 1, Name = "Bengaluru" },
                    new { Id = 2, Name = "Mumbai" },
                    new { Id = 3, Name = "Delhi" },
                    new { Id = 4, Name = "Chennai" },
                    new { Id = 5, Name = "Hyderabad" }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.Module", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Modules");

                b.HasData(
                    new { Id = 1, Name = "ModuleA" },
                    new { Id = 2, Name = "ModuleB" },
                    new { Id = 3, Name = "ModuleC" },
                    new { Id = 4, Name = "ModuleD" },
                    new { Id = 5, Name = "ModuleE" }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.Role", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Roles");

                b.HasData(
                    new { Id = 1, Name = "Admin" },
                    new { Id = 2, Name = "User" },
                    new { Id = 3, Name = "Manager" },
                    new { Id = 4, Name = "Staff" },
                    new { Id = 5, Name = "Guest" }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("PasswordHash")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Username")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Users");

                b.HasData(
                    new { Id = 1, Username = "user1", PasswordHash = "AT/G9IR6v8qQIPHEVWXttkWvp7pe6CyX/57XTL+VWg3oTNnA6D9kfQCvy/f66zTBNg==" },
                    new { Id = 2, Username = "user2", PasswordHash = "AafM2hH9uXftvNzus2JY3NhbS5YQS3m0OwZqSGlcoFRmUw7fWzG0la7DrVhlLQuZgQ==" }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.Employee", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Code")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("DepartmentId")
                    .HasColumnType("int");

                b.Property<int>("DivisionId")
                    .HasColumnType("int");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime?>("EndDate")
                    .HasColumnType("datetime2");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Gender")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("JobTitleId")
                    .HasColumnType("int");

                b.Property<int>("LocationId")
                    .HasColumnType("int");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("MiddleName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Phone")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int?>("ReportingManagerId")
                    .HasColumnType("int");

                b.Property<DateTime>("StartDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Status")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("DepartmentId");

                b.HasIndex("DivisionId");

                b.HasIndex("JobTitleId");

                b.HasIndex("LocationId");

                b.HasIndex("ReportingManagerId");

                b.ToTable("Employees");

                b.HasData(
                    new
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
                        ReportingManagerId = (int?)null,
                        Gender = "Male",
                        StartDate = new DateTime(2020, 1, 1),
                        EndDate = (DateTime?)null,
                        Status = "Active"
                    },
                    new
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
                        EndDate = (DateTime?)null,
                        Status = "Active"
                    }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.EmployeeLocationAssignment", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int>("EmployeeId")
                    .HasColumnType("int");

                b.Property<int>("LocationId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("EmployeeId");

                b.HasIndex("LocationId");

                b.ToTable("EmployeeLocationAssignments");

                b.HasData(
                    new { Id = 1, EmployeeId = 1, LocationId = 1 },
                    new { Id = 2, EmployeeId = 2, LocationId = 2 }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.EmployeeModuleAssignment", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int>("EmployeeId")
                    .HasColumnType("int");

                b.Property<int>("ModuleId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("EmployeeId");

                b.HasIndex("ModuleId");

                b.ToTable("EmployeeModuleAssignments");

                b.HasData(
                    new { Id = 1, EmployeeId = 1, ModuleId = 1 },
                    new { Id = 2, EmployeeId = 2, ModuleId = 2 }
                );
            });

            modelBuilder.Entity("Kolme.API.Data.Entities.EmployeeRoleAssignment", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int>("EmployeeId")
                    .HasColumnType("int");

                b.Property<int>("RoleId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("EmployeeId");

                b.HasIndex("RoleId");

                b.ToTable("EmployeeRoleAssignments");

                b.HasData(
                    new { Id = 1, EmployeeId = 1, RoleId = 1 },
                    new { Id = 2, EmployeeId = 2, RoleId = 2 }
                );
            });
#pragma warning restore 612, 618
        }
    }
}
