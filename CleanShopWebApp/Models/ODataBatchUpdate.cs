namespace CleanShopWebApp.Models;

public class ODataBatchUpdate
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int NewStock { get; set; }
}
