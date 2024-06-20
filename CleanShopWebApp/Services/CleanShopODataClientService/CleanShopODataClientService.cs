using CleanShopWebApp.Models;
using CleanShopWebApp.Models.CleanShopOData;
using Simple.OData.Client;

namespace CleanShopWebApp.Services.CleanShopODataClientService;

public partial class CleanShopODataClientService
{
    private readonly HttpClient _httpClient;
    private readonly ODataClientSettings _settings;

    public CleanShopODataClientService(HttpClient httpClient, ODataClientSettings settings)
    {
        _httpClient = httpClient;
        _settings = settings;
    }

    public async Task<IEnumerable<Producto>> GetProductsAsync()
    {
        var client = new ODataClient(_settings);
        var products = await client.For<Producto>().FindEntriesAsync();
        return products;
    }

    public async Task<Producto> GetProductByIdAsync(int id)
    {
        var client = new ODataClient(_settings);
        var product = await client.For<Producto>()
            .Key(id)
            .FindEntryAsync();
        return product;
    }

    public async Task InsertSalesAsync(IEnumerable<Venta> sales)
    {
        var client = new ODataClient(_settings);
        var batch = new ODataBatch(client);
        batch += async c =>
        {
            foreach (var sale in sales)
            {
                await c.For<Venta>().Set(new
                {
                    sale.Idproductos,
                    sale.Fecha,
                    sale.CantidadVendida
                }).InsertEntryAsync();
            }
        };
        await batch.ExecuteAsync();
    }

    public async Task UpdateProductStockAsync(List<ODataBatchUpdate> values)
    {
        var client = new ODataClient(_settings);
        var batch = new ODataBatch(client);
        batch += async c =>
        {
            foreach (var value in values)
            {
                await c.For<Producto>()
                .Key(value.Id)
                .Set(new
                {
                    Existencias = value.NewStock
                }).UpdateEntryAsync();
            }
        };
        await batch.ExecuteAsync();
    }
}