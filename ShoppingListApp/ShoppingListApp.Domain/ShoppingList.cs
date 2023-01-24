namespace ShoppingListApp.Domain;

public class ShoppingList
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<ShoppingListItem> Items { get; set; }
}