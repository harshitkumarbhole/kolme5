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
            });
#pragma warning restore 612, 618
        }
    }
}
