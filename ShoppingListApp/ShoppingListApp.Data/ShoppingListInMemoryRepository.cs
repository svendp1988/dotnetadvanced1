using ShoppingListApp.Business.Contracts;

namespace ShoppingListApp.Data;

// public class ShoppingListInMemoryRepository: IShoppingListRepository
// {
    //    public IReadOnlyList<ShoppingListSummaryDto> GetAll()
    //    {
    //        var result = new List<ShoppingListSummaryDto>();
    //        for (int weekNumber = 1; weekNumber <= 3; weekNumber++)
    //        {
    //            result.Add(new ShoppingListSummaryDto { Id = weekNumber, Title = $"Week {weekNumber}" });
    //        }
    //        return result;
    //    }

    //    public ShoppingList GetById(int id)
    //    {
    //        return new ShoppingList
    //        {
    //            Id = id,
    //            Title = $"Week {id}",
    //            Items = new List<ShoppingListItem>
    //            {
    //                new ShoppingListItem
    //                {
    //                    Index = 1,
    //                    Shop = new Shop{Id = 1, Name = "DummyShop"},
    //                    ShopId = 1,
    //                    Text = "Item with shop"
    //                },
    //                new ShoppingListItem
    //                {
    //                    Index = 2,
    //                    Text = "Item without shop"
    //                }
    //            }
    //        };
    //    }
// }