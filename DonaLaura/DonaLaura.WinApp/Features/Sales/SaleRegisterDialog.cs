using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DonaLaura.WinApp.Features.Sales
{
    public partial class SaleRegisterDialog : Form
    {
        private Sale _sale;
        private List<Product> listProducts = new List<Product>();
        private List<int> listAmount = new List<int>();
        private decimal profit = 0;

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
            if (cmbProducts.SelectedItem != null)
            {
                if (cmbProducts.SelectedItem.ToString().Contains("Sim"))
                {
                    listProducts.Add((Product)cmbProducts.SelectedItem);
                    listAmount.Add((int)numAmount.Value);

                    var text = string.Format("Produto: {0} - Quantidade: {1}", listProducts.Last().Name, numAmount.Value);
                    listBoxProducts.Items.Add(text);

                    profit += (listProducts.Last().SalePrice - listProducts.Last().CostPrice) * numAmount.Value;
                    txtProfit.Text = profit.ToString();
                }
                else
                    throw new ArgumentNullException("Este produto não consta em estoque!");
            }
            
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem != null)
            {
                listBoxProducts.Items.Remove(listBoxProducts.SelectedItem);

                if (profit > 0)
                {
                    profit -= (listProducts.Last().SalePrice - listProducts.Last().CostPrice) * numAmount.Value;
                    txtProfit.Text = profit.ToString();
                }
                else
                    txtProfit.Text = "0,00";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_sale == null)
            {
                _sale = new Sale();
            }

            _sale.Id = int.Parse(txtId.Text);
            _sale.Customer = txtCustomer.Text.Trim();
            _sale.Products = listProducts;
            _sale.Amount = listAmount;
            _sale.Profit = 0;
            for (int i = 0; i < _sale.Amount.Count; i++)
            {
                _sale.Profit += (_sale.Products[i].SalePrice - _sale.Products[i].CostPrice) * _sale.Amount[i];
            }

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
