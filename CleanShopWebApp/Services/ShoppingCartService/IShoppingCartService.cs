using CleanShopWebApp.Models;
using CleanShopWebApp.Models.CleanShopOData;

namespace CleanShopWebApp.Services.ShoppingCartService;
public interface IShoppingCartService
{
    /// <summary>
    /// Obtiene los items del carrito de compras
    /// </summary>
    /// <returns></returns>
    List<CartItem> Items { get; }

    /// <summary>
    /// Obtiene el precio total del carrito de compras
    /// </summary>
    decimal TotalPrice { get; }

    /// <summary>
    /// Obtiene la cantidad de items en el carrito de compras
    /// </summary>
    int ItemsCount { get; }

    /// <summary>
    /// Agrega un item al carrito de compras
    /// </summary>
    /// <param name="item"></param>
    void AddItem(Producto product);

    /// <summary>
    /// Quita un item del carrito de compras
    /// </summary>
    /// <param name="productId"></param>
    void RemoveItem(Producto product);

    /// <summary>
    /// Limpia un item del carrito de compras
    /// </summary>
    /// <param name="productId"></param>
    void ClearItem(int productId);

    /// <summary>
    /// Limpia el carrito de compras
    /// </summary>
    void ClearCart();

    /// <summary>
    /// Verifica si el carrito de compras contiene un item
    /// </summary>
    /// <param name="productId"></param>
    /// <returns>Devuelve true si el item ya está agregado. De lo contrario regresa false.</returns>
    bool ContainsItem(int productId);
}