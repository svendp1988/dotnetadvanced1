using ShoppingListApp.Domain;

namespace ShoppingListApp.Business.Contracts;

public interface IShoppingListRepository
{
    /// <summary>
    /// Returns a summary (id and title) of all shopping lists
    /// </summary>
    IReadOnlyList<ShoppingListSummaryDto> GetAll();

    /// <summary>
    /// Returns a shopping list with its items.
    /// The shops of the items are also included.
    /// </summary>
    /// <param name="id">Identifier of the shopping list</param>
    ShoppingList? GetById(int id);

    Shop? GetShopById(int? id);
}