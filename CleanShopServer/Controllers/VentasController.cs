using CleanShopServer.ContextDb.CleanShopDb;
using CleanShopServer.Models.CleanShopDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CleanShopServer.Controllers;

public class VentasController(CleanShopDbContext context) : ODataController
{
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(context.Ventas);
    }

    [EnableQuery]
    public IActionResult Get([FromRoute] int key)
    {
        return Ok(context.Ventas.Include(x => x.Producto).FirstOrDefault(x => x.IdVentas == key));
    }

    [EnableQuery]
    public IActionResult Post([FromBody] Venta venta)
    {
        context.Ventas.Add(new Venta
        {
            Idproductos = venta.Idproductos,
            CantidadVendida = venta.CantidadVendida,
            Fecha = venta.Fecha
        });
        context.SaveChanges();
        return Created(venta);
    }

    [EnableQuery]
    public IActionResult Put([FromRoute] int key, [FromBody] Venta venta)
    {
        venta.IdVentas = key;
        context.Ventas.Update(venta);
        context.SaveChanges();
        return Updated(venta);
    }

    [EnableQuery]
    public IActionResult Patch([FromRoute] int key, [FromBody] Delta<Venta> venta)
    {
        var entity = context.Ventas.Find(key);
        if (entity == null)
        {
            return NotFound();
        }
        venta.Patch(entity);
        context.SaveChanges();
        return Updated(entity);
    }

    [EnableQuery]
    public IActionResult Delete([FromRoute] int key)
    {
        var entity = context.Ventas.Find(key);
        if (entity == null)
        {
            return NotFound();
        }
        context.Ventas.Remove(entity);
        context.SaveChanges();
        return NoContent();
    }
}
