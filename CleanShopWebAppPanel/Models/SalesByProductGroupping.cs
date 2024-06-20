using CleanShopWebAppPanel.Models.CleanShopOData;

namespace CleanShopWebAppPanel.Models
{
    public class SalesByProductGroupping
    {
        public int? IdProductos { get; set; }
        public decimal? Total { get; set; }
        public Producto? Producto { get; set; }
    }
}
