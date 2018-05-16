using DonaLaura.Applications.Features;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Infra.Data.Features.Products;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DonaLaura.WinApp.Features.Products
{
    public partial class ProductControl : UserControl
    {
        private IProductRepository _productRepository;
        private ProductService _productService;

        public ProductControl()
        {
            InitializeComponent();

            _productRepository = new ProductRepository();
            _productService = new ProductService(_productRepository);
        }

        public void PopulateProductsListing(IList<Product> products)
        {
            dgvProducts.DataSource = null;

            if (products == null)
                return;

            dgvProducts.DataSource = products;
            SetDataGrid();
        }

        public Product GetSelectedProduct()
        {
            try
            {
                return dgvProducts.CurrentRow.DataBoundItem as Product;
            }
            catch
            {
                return null;
            }
        }

        private void SetDataGrid()
        {
            dgvProducts.Columns["ID"].Visible = false;
        }
    }
}
