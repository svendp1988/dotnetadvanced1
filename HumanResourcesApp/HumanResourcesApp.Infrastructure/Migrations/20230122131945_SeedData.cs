using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResourcesApp.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Dream team" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeNumber", "FirstName", "LastName", "TeamId", "Type" },
                values: new object[,]
                {
                    { "10000001", "Bill", "Gates", 1, 1 },
                    { "20001010", "Scott", "Hanselman", 1, 0 },
                    { "20001011", "Lisa", "Cohen", 1, 0 },
                    { "20001012", "Bart", "De Smet", 1, 0 },
                    { "20001013", "Julie", "Lerman", 1, 0 },
                    { "20001014", "Shawn", "Wildermuth", 1, 0 },
                    { "20001015", "Martin", "Hinshelwood", 1, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: "10000001");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: "20001010");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: "20001011");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: "20001012");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: "20001013");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: "20001014");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeNumber",
                keyValue: "20001015");

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
