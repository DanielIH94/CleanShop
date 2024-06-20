using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanShopServer.Models.CleanShopDb;

public partial class Venta
{
    [Key]
    public int IdVentas { get; set; }

    public int? Idproductos { get; set; }

    public int? CantidadVendida { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Producto? Producto { get; set; }
}
