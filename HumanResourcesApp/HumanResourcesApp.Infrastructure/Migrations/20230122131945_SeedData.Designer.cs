// <auto-generated />
using HumanResourcesApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HumanResourcesApp.Infrastructure.Migrations
{
    [DbContext(typeof(HumanResourcesContext))]
    [Migration("20230122131945_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HumanResourcesApp.Domain.Employee", b =>
                {
                    b.Property<string>("EmployeeNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("EmployeeNumber");

                    b.HasIndex("TeamId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeNumber = "20001010",
                            FirstName = "Scott",
                            LastName = "Hanselman",
                            TeamId = 1,
                            Type = 0
                        },
                        new
                        {
                            EmployeeNumber = "20001011",
                            FirstName = "Lisa",
                            LastName = "Cohen",
                            TeamId = 1,
                            Type = 0
                        },
                        new
                        {
                            EmployeeNumber = "20001012",
                            FirstName = "Bart",
                            LastName = "De Smet",
                            TeamId = 1,
                            Type = 0
                        },
                        new
                        {
                            EmployeeNumber = "20001013",
                            FirstName = "Julie",
                            LastName = "Lerman",
                            TeamId = 1,
                            Type = 0
                        },
                        new
                        {
                            EmployeeNumber = "20001014",
                            FirstName = "Shawn",
                            LastName = "Wildermuth",
                            TeamId = 1,
                            Type = 0
                        },
                        new
                        {
                            EmployeeNumber = "20001015",
                            FirstName = "Martin",
                            LastName = "Hinshelwood",
                            TeamId = 1,
                            Type = 0
                        },
                        new
                        {
                            EmployeeNumber = "10000001",
                            FirstName = "Bill",
                            LastName = "Gates",
                            TeamId = 1,
                            Type = 1
                        });
                });

            modelBuilder.Entity("HumanResourcesApp.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dream team"
                        });
                });

            modelBuilder.Entity("HumanResourcesApp.Domain.Employee", b =>
                {
                    b.HasOne("HumanResourcesApp.Domain.Team", null)
                        .WithMany("Employees")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HumanResourcesApp.Domain.Team", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
