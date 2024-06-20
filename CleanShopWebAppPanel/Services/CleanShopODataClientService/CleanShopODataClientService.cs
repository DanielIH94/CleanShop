using CleanShopWebAppPanel.Models.CleanShopOData;
using Simple.OData.Client;

namespace CleanShopWebAppPanel.Services.CleanShopODataClientService;

public partial class CleanShopODataClientService
{
    private readonly HttpClient _httpClient;
    private readonly ODataClientSettings _settings;

    public CleanShopODataClientService(HttpClient httpClient, ODataClientSettings settings)
    {
        _httpClient = httpClient;
        _settings = settings;
    }

    public async Task<IEnumerable<Venta>> GetSalesProductAsync()
    {
        var client = new ODataClient(_settings);
        var sales = await client
            .For<Venta>()
            .Expand(x => x.Producto)
            .FindEntriesAsync();
        return sales;
    }

    public async Task<IEnumerable<Venta>> GetBestSellingProductsAsync(int top)
    {
        var client = new ODataClient(_settings);
        var sales = await client
            .For<Venta>()
            .Expand(x => x.Producto)
            .OrderByDescending(x => x.CantidadVendida)
            .Top(top)
            .FindEntriesAsync();
        return sales;
    }

    public async Task<IEnumerable<Producto>> GetProductsAsync()
    {
        var client = new ODataClient(_settings);
        var products = await client
            .For<Producto>()
            .FindEntriesAsync();
        return products;
    }
}