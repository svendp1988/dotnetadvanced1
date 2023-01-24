using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingListApp.Domain;

namespace ShoppingListApp.Data;

internal class ShoppingListContext : DbContext
{
    public DbSet<ShoppingList> ShoppingLists => Set<ShoppingList>();

    private static readonly ILoggerFactory DebugLoggerFactory
        = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information);
        });


    private List<Shop> GetShopSeedData()
    {
        return new List<Shop>
        {
            new() {Id = 1, Name = "Aldi"},
            new() {Id = 2, Name = "Lidl"},
            new() {Id = 3, Name = "Delhaize"}
        };
    }
    
    private List<ShoppingList> GetShoppingListSeedData()
    {
        return new List<ShoppingList>
        {
            new()
            {
                Id = 1,
                Title = "Week 1",
            },
            new()
            {
                Id = 2,
                Title = "Week 2"
            }
        };
    }
    
    private List<ShoppingListItem> GetShoppingListItemSeedData()
    {
        return new List<ShoppingListItem>
        {
            new() {Id = 1, ShoppingListId = 1, Index = 0, Text = "Carrots", ShopId = 1},
            new() {Id = 2, ShoppingListId = 1, Index = 1, Text = "Candy"},
            new() {Id = 3, ShoppingListId = 1, Index = 2, Text = "Water", ShopId = 3},
    
            new() {Id = 4, ShoppingListId = 2, Index = 0, Text = "Apples"},
            new() {Id = 5, ShoppingListId = 2, Index = 1, Text = "Potatoes", ShopId = 2},
            new() {Id = 6, ShoppingListId = 2, Index = 2, Text = "Chicken", ShopId = 2},
            new() {Id = 7, ShoppingListId = 2, Index = 3, Text = "Cheese", ShopId = 2}
        };
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShoppingListDb;Integrated Security=True;";
        optionsBuilder
            .UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shop>()
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
        modelBuilder.Entity<Shop>()
            .ToTable("Shops");
        modelBuilder.Entity<ShoppingListItem>()
            .Property(e => e.Text)
            .IsRequired();
        modelBuilder.Entity<ShoppingListItem>()
            .ToTable("ShoppingListItems");

        modelBuilder.Entity<Shop>().HasData(GetShopSeedData());
        modelBuilder.Entity<ShoppingList>().HasData(GetShoppingListSeedData());
        modelBuilder.Entity<ShoppingListItem>().HasData(GetShoppingListItemSeedData());
    }
}