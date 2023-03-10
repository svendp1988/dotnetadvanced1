using ShoppingListApp.Business;
using ShoppingListApp.Business.Contracts;
using ShoppingListApp.Domain;

namespace ShoppingListApp.Data;

internal class ShoppingListDbRepository : IShoppingListRepository
{
    private readonly ShoppingListContext _context;
    
    public ShoppingListDbRepository()
    {
        _context = new ShoppingListContext();
    }

    public IReadOnlyList<ShoppingListSummaryDto> GetAll()
    {
        return _context.ShoppingLists.Select(list => new ShoppingListSummaryDto
        {
            Id = list.Id,
            Title = list.Title
        }).ToList();
    }

    public ShoppingList? GetById(int id)
    {
        return _context.ShoppingLists.FirstOrDefault(list => list != null && list.Id.Equals(id), null);
    }
}