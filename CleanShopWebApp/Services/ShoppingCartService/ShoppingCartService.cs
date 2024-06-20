using CleanShopWebApp.Models;
using CleanShopWebApp.Models.CleanShopOData;

namespace CleanShopWebApp.Services.ShoppingCartService;
public class ShoppingCartService : IShoppingCartService
{
    private List<CartItem> items = [];

    public List<CartItem> Items => items;

    public decimal TotalPrice => items.Sum(i => i.TotalPrice);

    public int ItemsCount => items.Sum(i => i.Quantity);

    public void AddItem(Producto product)
    {
        var existingItem = items.FirstOrDefault(i => i.Product.IdProductos == product.IdProductos);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            items.Add(new CartItem
            {
                Product = product,
                Quantity = 1
            });
        }
    }

    public void RemoveItem(Producto product)
    {
        var existingItem = items.FirstOrDefault(i => i.Product.IdProductos == product.IdProductos);
        if (existingItem != null)
        {
            if (existingItem.Quantity > 1)
            {
                existingItem.Quantity--;
            }
            else
            {
                ClearItem(product.IdProductos);
            }
        }
    }

    public void ClearItem(int productId)
    {
        items = items.Where(i => i.Product.IdProductos != productId).ToList();
    }

    public void ClearCart() {
        items = [];
    }

    public bool ContainsItem(int productId) => items.Any(i => i.Product.IdProductos == productId);
}
