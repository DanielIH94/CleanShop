using CleanShopWebApp.Models.CleanShopOData;

namespace CleanShopWebApp.Models;

public class CartItem
{
    public required Producto Product { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal TotalPrice => Product.PrecioUnitario * Quantity;
}
