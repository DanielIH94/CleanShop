using CleanShopServer.ContextDb.CleanShopDb;
using CleanShopServer.Models.CleanShopDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CleanShopServer.Controllers;

public class ProductosController(CleanShopDbContext context) : ODataController
{
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(context.Productos);
    }

    [EnableQuery]
    public IActionResult Get([FromRoute] int key)
    {
        return Ok(context.Productos.Include(x => x.Ventas).FirstOrDefault(x => x.IdProductos == key));
    }

    [EnableQuery]
    public IActionResult Post([FromBody] Producto producto)
    {
        context.Productos.Add(producto);
        context.SaveChanges();
        return Created(producto);
    }

    [EnableQuery]
    public IActionResult Put([FromRoute] int key, [FromBody] Producto producto)
    {
        producto.IdProductos = key;
        context.Productos.Update(producto);
        context.SaveChanges();
        return Updated(producto);
    }

    [EnableQuery]
    public IActionResult Patch([FromRoute] int key, [FromBody] Delta<Producto> producto)
    {
        var entity = context.Productos.Find(key);
        if (entity == null) {
            return NotFound();
        }
        producto.Patch(entity);
        context.SaveChanges();
        return Updated(entity);
    }

    [EnableQuery]
    public IActionResult Delete([FromRoute] int key)
    {
        var entity = context.Productos.Find(key);
        if (entity == null)
        {
            return NotFound();
        }
        context.Productos.Remove(entity);
        context.SaveChanges();
        return NoContent();
    }
}
