using CleanShopDesktop.Models;
using CleanShopServer.Models.CleanShopDb;
using Default;

namespace CleanShopDesktop.Services;

internal class CleanShopODataService
{
    private readonly Container OData;

    public CleanShopODataService()
    {
        OData = new Container(new Uri("https://localhost:7291/odata"));
    }

    public async Task<List<Venta>> GetSalesProductAsync()
    {
        var sales = await OData.Ventas
            .Expand(x => x.Producto)
            .ExecuteAsync();
        return sales.ToList();
    }

    public async Task<List<BestSale>> GetBestSellingProductsAsync(int top)
    {
        var sales = await OData.Ventas
            .Expand(x => x.Producto)
            .ExecuteAsync();
        var topSales = sales.OrderByDescending(x => x.CantidadVendida).Take(top).ToList();
        return topSales.Select(x => new BestSale
        {
            Posicion = topSales.IndexOf(x) + 1,
            Titulo = x.Producto.Titulo,
            Cantidad = x.CantidadVendida
        }).ToList();
    }

    public async Task<List<InventoryItem>> GetInventoryAsync()
    {
        var products = await OData.Productos
            .ExecuteAsync();
        return products.Select(x => new InventoryItem()
        {
            IdProducto = x.IdProductos,
            Titulo = x.Titulo,
            Descripcion = x.Descripcion,
            Existencia = x.Existencias
        }).ToList();
    }
}
