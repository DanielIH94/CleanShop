namespace CleanShopDesktop.Models;

internal class InventoryItem
{
    public int IdProducto { get; set; }
    public required string Titulo { get; set; }
    public string? Descripcion { get; set; }
    public int Existencia { get; set; }
}
