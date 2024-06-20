using CleanShopDesktop.Models;
using CleanShopDesktop.Services;
using CleanShopServer.Models.CleanShopDb;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace CleanShopDesktop;

public partial class CSForm : Form
{
    private readonly CleanShopODataService _cleanShopODataService;
    private CSTabIndex _currentTabIndex;

    public CSForm()
    {
        _cleanShopODataService = new CleanShopODataService();
        _currentTabIndex = CSTabIndex.ProductsSales;
        InitializeComponent();
    }

    private void CSForm_Load(object sender, EventArgs e)
    {
        LoadData(
            GetProductSalesData,
            data => ProductsSalesGrid.DataSource = data
        );
    }

    private void ActionTabs_SelectedIndexChanged(object sender, EventArgs e)
    {
        _currentTabIndex = (CSTabIndex)ActionTabs.SelectedIndex;
        RunTab(_currentTabIndex);
    }

    private void RetryBtn_Click(object sender, EventArgs e)
    {
        RunTab(_currentTabIndex);
    }

    //Data methods
    private async Task<BindingSource> GetProductSalesData()
    {
        var sales = await _cleanShopODataService.GetSalesProductAsync();
        var salesByProductGroupping = sales
            .GroupBy(x => x.Idproductos)
            .Select(g => new SalesByProductGroupping()
            {
                IdProductos = g.Key,
                Total = g.Sum(x =>
                    x.CantidadVendida * (g.FirstOrDefault()?.Producto?.PrecioUnitario ?? 0)
                ),
                Titulo = g.FirstOrDefault()?.Producto.Titulo
            }
            ).ToList();
        var bindingList = new BindingList<SalesByProductGroupping>(salesByProductGroupping);
        var source = new BindingSource(salesByProductGroupping, null);
        return source;
    }

    private async Task<decimal?> GetGlobalSales()
    {
        var sales = await _cleanShopODataService.GetSalesProductAsync();
        return sales.Sum(x => x.CantidadVendida * (x.Producto?.PrecioUnitario ?? 0));
    }

    private async Task<BindingSource> GetBestSellingProducts()
    {
        var sales = await _cleanShopODataService.GetBestSellingProductsAsync(5);
        var bindingList = new BindingList<BestSale>(sales);
        var source = new BindingSource(bindingList, null);
        return source;
    }

    private async Task<BindingSource> GetInventory()
    {
        var products = await _cleanShopODataService.GetInventoryAsync();
        var bindingList = new BindingList<InventoryItem>(products);
        var source = new BindingSource(bindingList, null);
        return source;
    }


    //Generic methods
    private void LoadData<T>(Func<Task<T>> run, Action<T> body)
    {
        StatusTextbox.Text = "Cargando...";
        RetryBtn.Enabled = false;
        run().ContinueWith(task =>
        {
            Invoke((MethodInvoker)delegate
            {
                if (task.IsFaulted)
                {
                    MessageBox.Show(
                        "Ocurrió un error. \nNo fue posible conectar con los servicios de datos.",
                        "Error de conexión"
                    );
                    RetryBtn.Enabled = true;
                }
                else
                {
                    body(task.Result);
                }
                StatusTextbox.Text = string.Empty;
            });
        });
    }

    private void RunTab(CSTabIndex tabIndex)
    {
        switch (tabIndex)
        {
            case CSTabIndex.ProductsSales:
                LoadData(
                    GetProductSalesData,
                    data => ProductsSalesGrid.DataSource = data
                );
                break;
            case CSTabIndex.GlobalSales:
                LoadData(
                    GetGlobalSales,
                    data => GlobalSalesTextBox.Text = (data ?? 0)
                    .ToString("C2", CultureInfo.CreateSpecificCulture("es-MX"))
                );
                break;
            case CSTabIndex.BestSeller:
                LoadData(
                    GetBestSellingProducts,
                    data => BestSellersGridView.DataSource = data
                );
                break;
            case CSTabIndex.Inventory:
                LoadData(
                    GetInventory,
                    data => InventoryGridView.DataSource = data
                );
                break;
            default:
                MessageBox.Show("No se ha implementado la funcionalidad para esta pestaña.");
                break;
        }
    }
}
