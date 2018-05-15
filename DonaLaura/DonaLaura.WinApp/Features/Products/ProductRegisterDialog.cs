using DonaLaura.Domain.Features.Products;
using System;
using System.Windows.Forms;

namespace DonaLaura.WinApp.Features.Products
{
    public partial class ProductRegisterDialog : Form
    {
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;

                txtId.Text = _product.Id.ToString();
                txtName.Text = _product.Name;
                txtCostPrice.Text = _product.CostPrice.ToString();
                txtSalePrice.Text = _product.SalePrice.ToString();
                chbxIsAvailable.Checked = _product.IsAvailable;
                dtFabrication.Value = _product.Fabrication;
                dtExpiration.Value = _product.Expiration;
            }
        }

        public ProductRegisterDialog()
        {
            InitializeComponent();
        }

        public ProductRegisterDialog(Product productSelecionado)
        {
            InitializeComponent();

            Product = productSelecionado;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (_product == null)
            {
                _product = new Product();
            }

            _product.Name = txtName.Text;
            _product.CostPrice = Convert.ToDecimal(txtCostPrice.Text);
            _product.SalePrice = Convert.ToDecimal(txtSalePrice.Text);
            _product.IsAvailable = Convert.ToBoolean(chbxIsAvailable.Checked);
            _product.Fabrication = Convert.ToDateTime(dtFabrication);
            _product.Expiration = Convert.ToDateTime(dtExpiration);


            try
            {
                _product.Validate();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
