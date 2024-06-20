using CleanShopWebApp;
using CleanShopWebApp.Services.CleanShopODataClientService;
using CleanShopWebApp.Services.ShoppingCartService;
using CleanShopWebApp.Services.WebSocketService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Simple.OData.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ShoppingCartService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<WebSocketService>();
builder.Services.AddScoped(sp =>
    new CleanShopODataClientService(sp.GetRequiredService<HttpClient>(), new ODataClientSettings(new Uri("https://localhost:7291/odata/"))
    {
        IgnoreResourceNotFoundException = true
    })
);
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
