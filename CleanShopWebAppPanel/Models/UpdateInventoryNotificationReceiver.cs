namespace CleanShopWebAppPanel.Models;

public class UpdateInventoryNotificationReceiver
{
    public int Type { get; set; }
    public List<InventoryUpdatesListItem> InventroyUpdate { get; set; } = [];
}
