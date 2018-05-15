using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DonaLaura.WinApp.Features.Sales
{
    public partial class SaleRegisterDialog : Form
    {
        private Sale _sale;

        public Sale Sale
        {
            get { return _sale; }
            set
            {
                _sale = value;

                txtId.Text = _sale.Id.ToString().Trim();
                txtCustomer.Text = _sale.Customer.Trim();
                txtProfit.Text = _sale.Profit.ToString();

                foreach (var item in _sale.Products)
                {
                    listBoxProducts.Items.Add(item);
                }
            }
        }

        public SaleRegisterDialog(IList<Product> products)
        {
            InitializeComponent();

            if (products == null || products.Count == 0)
                throw new ArgumentNullException("Deve ter produtos cadastrados!");

            UpdateCombobox(products);
        }

        public SaleRegisterDialog(Sale selectedSale, IList<Product> products)
        {
            InitializeComponent();

            UpdateCombobox(products);

            Sale = selectedSale;
        }

        private void UpdateCombobox(IList<Product> products)
        {
            cmbProducts.Items.Clear();

            foreach (var item in products)
            {
                cmbProducts.Items.Add(item);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (!listBoxProducts.Items.Contains(cmbProducts.SelectedItem))
                listBoxProducts.Items.Add(cmbProducts.SelectedItem);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            listBoxProducts.Items.Remove(listBoxProducts.SelectedItem);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_sale == null)
            {
                _sale = new Sale();
            }

            IList<Product> list = new List<Product>();

            _sale.Id = int.Parse(txtId.Text);
            _sale.Customer = txtCustomer.Text.Trim();
            _sale.Profit = Convert.ToDecimal(txtProfit.Text);

            foreach (var item in listBoxProducts.Items)
            {
                list.Add(item as Product);
            }
            _sale.Products = list;

            try
            {
                _sale.Validate();
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
