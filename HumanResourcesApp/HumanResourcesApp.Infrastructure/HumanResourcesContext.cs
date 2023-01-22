using System.Diagnostics;
using HumanResourcesApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HumanResourcesApp.Infrastructure;

public class HumanResourcesContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Team> Teams => Set<Team>();

    public HumanResourcesContext()
    {
    }

    public HumanResourcesContext(DbContextOptions options) : base(options)
    {
    }

    public void EnsureIsMigrated()
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HumanResourcesDb;Integrated Security=True;";
        optionsBuilder
            .UseSqlServer(connectionString)
            .LogTo(message => Debug.WriteLine(message), new[]
            {
                DbLoggerCategory.Database.Command.Name
            }, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Property(e => e.EmployeeNumber)
            .HasMaxLength(20);
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.EmployeeNumber);

        var teamArray = new Team[]
        {
            new()
            {
                Id = 1,
                Name = "Dream team"
            }
        };
        modelBuilder.Entity<Team>().HasData(teamArray);

        var employeeArray = new Employee[]
        {
            new()
            {
                EmployeeNumber = "20001010",
                FirstName = "Scott",
                LastName = "Hanselman",
                TeamId = 1,
                Type = EmployeeType.Developer
            },
            new()
            {
                EmployeeNumber = "20001011",
                FirstName = "Lisa",
                LastName = "Cohen",
                TeamId = 1,
                Type = EmployeeType.Developer
            },
            new()
            {
                EmployeeNumber = "20001012",
                FirstName = "Bart",
                LastName = "De Smet",
                TeamId = 1,
                Type = EmployeeType.Developer
            },
            new()
            {
                EmployeeNumber = "20001013",
                FirstName = "Julie",
                LastName = "Lerman",
                TeamId = 1,
                Type = EmployeeType.Developer
            },
            new()
            {
                EmployeeNumber = "20001014",
                FirstName = "Shawn",
                LastName = "Wildermuth",
                TeamId = 1,
                Type = EmployeeType.Developer
            },
            new()
            {
                EmployeeNumber = "20001015",
                FirstName = "Martin",
                LastName = "Hinshelwood",
                TeamId = 1,
                Type = EmployeeType.Developer
            },
            new()
            {
                EmployeeNumber = "10000001",
                FirstName = "Bill",
                LastName = "Gates",
                TeamId = 1,
                Type = EmployeeType.AccountManager
            }
        };
        modelBuilder.Entity<Employee>().HasData(employeeArray);
    }
}