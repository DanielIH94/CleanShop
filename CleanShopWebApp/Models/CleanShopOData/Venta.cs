namespace CleanShopWebApp.Models.CleanShopOData;

public class Venta
{
    public int IdVentas { get; set; }

    public int? Idproductos { get; set; }

    public int? CantidadVendida { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Producto? Producto { get; set; }
}
