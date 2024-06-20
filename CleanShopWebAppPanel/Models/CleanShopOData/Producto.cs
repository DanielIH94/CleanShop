namespace CleanShopWebAppPanel.Models.CleanShopOData;

public partial class Producto
{
    public int IdProductos { get; set; }
    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int Existencias { get; set; }
    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
