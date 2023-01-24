using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApp.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Week 1" },
                    { 2, "Week 2" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Aldi" },
                    { 2, "Lidl" },
                    { 3, "Delhaize" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingListItems",
                columns: new[] { "Index", "ShoppingListId", "ShopId", "Text" },
                values: new object[,]
                {
                    { 1, 1, 1, "Carrots" },
                    { 2, 1, null, "Candy" },
                    { 3, 1, 3, "Water" },
                    { 1, 2, null, "Apples" },
                    { 2, 2, 2, "Potatoes" },
                    { 3, 2, 2, "Chicken" },
                    { 4, 2, 2, "Cheese" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoppingListItems",
                keyColumns: new[] { "Index", "ShoppingListId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListItems",
                keyColumns: new[] { "Index", "ShoppingListId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListItems",
                keyColumns: new[] { "Index", "ShoppingListId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListItems",
                keyColumns: new[] { "Index", "ShoppingListId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListItems",
                keyColumns: new[] { "Index", "ShoppingListId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListItems",
                keyColumns: new[] { "Index", "ShoppingListId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListItems",
                keyColumns: new[] { "Index", "ShoppingListId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
