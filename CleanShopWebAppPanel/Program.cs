using CleanShopWebAppPanel.Services.CleanShopODataClientService;
using CleanShopWebAppPanel;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Simple.OData.Client;
using CleanShopWebAppPanel.Services.WebSocketService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp =>
    new CleanShopODataClientService(sp.GetRequiredService<HttpClient>(), new ODataClientSettings(new Uri("https://localhost:7291/odata/"))
    {
        IgnoreResourceNotFoundException = true
    })
);
builder.Services.AddScoped<WebSocketService>();
await builder.Build().RunAsync();
