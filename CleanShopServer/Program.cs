using CleanShopServer.ContextDb.CleanShopDb;
using CleanShopServer.Models.CleanShopDb;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);
var modelBuilder = new ODataConventionModelBuilder();

modelBuilder.EntityType<Producto>();
modelBuilder.EntityType<Venta>();

modelBuilder
    .EntitySet<Producto>("Productos").EntityType
    .HasKey(producto => producto.IdProductos);
modelBuilder
    .EntitySet<Venta>("Ventas").EntityType
    .HasKey(venta => venta.IdVentas);

// Add services to the container.
builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel(),
        new DefaultODataBatchHandler()
    )
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CleanShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CleanShopDb"))
);

var app = builder.Build();

app.UseCors(builder =>
    builder
    .WithOrigins("https://localhost:7151", "https://localhost:7187")
    .AllowAnyMethod()
    .AllowAnyHeader()
);

if(app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

var webSocketOptions = new WebSocketOptions()
{
    KeepAliveInterval = TimeSpan.FromSeconds(120),
};

app.UseWebSockets(webSocketOptions);

app.UseODataBatching();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
