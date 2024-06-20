namespace CleanShopWebAppPanel.Models;

public class InventoryUpdatesListItem
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int NewStock { get; set; }
}
