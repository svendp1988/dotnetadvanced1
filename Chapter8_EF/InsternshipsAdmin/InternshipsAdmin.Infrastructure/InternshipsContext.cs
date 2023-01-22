using System.Configuration;
using InternshipsAdmin.Domain;
using Microsoft.EntityFrameworkCore;

namespace InternshipsAdmin.Infrastructure
{
    public class InternshipsContext : DbContext
    {
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Supervisor> Supervisors => Set<Supervisor>();

        public InternshipsContext()
        {
        }

        public InternshipsContext(DbContextOptions<InternshipsContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (ConfigurationManager.AppSettings.HasKeys())
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=Internships");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var companyList = new Company[]
            {
                new()
                {
                    CompanyId = 1,
                    Supervisors = new List<Supervisor>(),
                Name = "name",
                Address = "address",
                Zip = "zip",
                City = "city"}
            };
            modelBuilder.Entity<Company>().HasData(companyList);
        }
    }
}