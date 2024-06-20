namespace CleanShopWebApp.Models;

public class UpdateInventoryNotificationSender
{
    public int Type { get; set; }
    public List<ODataBatchUpdate> InventoryUpdate { get; set; } = [];
}
