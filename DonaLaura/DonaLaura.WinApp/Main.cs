using DonaLaura.Application.Features;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using DonaLaura.Infra.Data.Features.Products;
using DonaLaura.Infra.Data.Features.Sales;
using DonaLaura.WinApp.Features;
using DonaLaura.WinApp.Features.Products;
using DonaLaura.WinApp.Features.Sales;
using System;
using System.Windows.Forms;

namespace DonaLaura.WinApp
{
    public partial class Main : Form
    {
        private static IProductRepository _productRepository = new ProductRepository();
        private static ISaleRepository _saleRepository = new SaleRepository();

        private ProductService _productService = new ProductService(_productRepository);
        private SaleService _saleService = new SaleService(_saleRepository);

        private FormManager _manager;
        private ProductFormManager _productManager;
        private SaleFormManager _saleManager;

        public Main()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            _saleManager = new SaleFormManager(_saleService, _productService);

            LoadRegister(_saleManager);
        }

        private void LoadRegister(FormManager manager)
        {
            _manager = manager;

            lblStatus.Text = _manager.GetRegisterType();

            UserControl listagem = _manager.LoadLinsting();

            listagem.Dock = DockStyle.Fill;

            panControl.Controls.Clear();

            panControl.Controls.Add(listagem);

            _manager.UpdateList();

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            lblAdd.Enabled = true;
            lblDelete.Enabled = true;
            lblUpdate.Enabled = true;
        }

        private void productsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (_productManager == null)
                _productManager = new ProductFormManager(_productService);

            LoadRegister(_productManager);
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                _manager.Add();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _manager.Add();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _manager.Delete();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _manager.Update();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_saleManager == null)
                _saleManager = new SaleFormManager(_saleService, _productService);

            LoadRegister(_saleManager);
        }
    }
}
