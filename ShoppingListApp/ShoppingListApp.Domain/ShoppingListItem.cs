namespace ShoppingListApp.Domain;

public class ShoppingListItem
{
    public ShoppingList ShoppingList { get; set; }
    public int ShoppingListId { get; set; }
    public int Index { get; set; }
    public string Text { get; set; }
    public Shop Shop { get; set; }
    public int? ShopId { get; set; } //FYI: int? is the same as Nullable<int>. It makes sure that the ShopId can also be null
}