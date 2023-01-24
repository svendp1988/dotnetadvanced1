namespace ShoppingListApp.Business;

public class ShoppingListSummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; }

    public override string ToString()
    {
        return Title;
    }
}