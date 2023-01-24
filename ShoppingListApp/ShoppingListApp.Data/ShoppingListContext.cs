using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
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
                Title = "Week 1"
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
            new() {ShoppingListId = 1, Index = 1, Text = "Carrots", ShopId = 1},
            new() {ShoppingListId = 1, Index = 2, Text = "Candy"},
            new() {ShoppingListId = 1, Index = 3, Text = "Water", ShopId = 3},

            new() {ShoppingListId = 2, Index = 1, Text = "Apples"},
            new() {ShoppingListId = 2, Index = 2, Text = "Potatoes", ShopId = 2},
            new() {ShoppingListId = 2, Index = 3, Text = "Chicken", ShopId = 2},
            new() {ShoppingListId = 2, Index = 4, Text = "Cheese", ShopId = 2}
        };
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ShoppingListDb;Integrated Security=True;";
        optionsBuilder
            .UseSqlServer(connectionString)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shop>(eb =>
            {
                eb.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                eb.ToTable("Shops");
            });
        modelBuilder.Entity<ShoppingList>(eb =>
        {
            eb.OwnsMany(list => list.Items, item =>
            {
                item.ToTable("ShoppingListItems");
                item.HasKey(li => new { li.ShoppingListId, li.Index });
                item.Property(sli => sli.Text)
                    .IsRequired();
                item.HasData(GetShoppingListItemSeedData());
            });
        });

        modelBuilder.Entity<Shop>().HasData(GetShopSeedData());
        modelBuilder.Entity<ShoppingList>().HasData(GetShoppingListSeedData());
    }
    
    
}