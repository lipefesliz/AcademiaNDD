using DonaLaura.Applications.Features;
using DonaLaura.Domain.Features.Products;
using DonaLaura.Domain.Features.Sales;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DonaLaura.WinApp.Features.Sales
{
    public class SaleFormManager : FormManager
    {
        private readonly SaleService _saleService;
        private readonly ProductService _productService;

        private SaleControl _saleControl;

        private IList<Product> _products;

        public SaleFormManager(SaleService saleService, ProductService produtcService)
        {
            _saleService = saleService;
            _productService = produtcService;
        }

        public override void Add()
        {
            UpdateComboBox();

            SaleRegisterDialog dialog = new SaleRegisterDialog(_products);
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _saleService.Add(dialog.Sale);
                ListSales();
            }
        }

        private void ListSales()
        {
            IList<Sale> sale = _saleService.GetAll();

            _saleControl.PopulateSalesLinsting(sale);
        }

        public override void UpdateList()
        {
            ListSales();
        }

        public override void Delete()
        {
            Sale selectedSala = _saleControl.GetSelectedSale();

            if (selectedSala != null)
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir a venda "
                    + selectedSala.Id, "Excluir venda",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        _saleService.Delete(selectedSala);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    ListSales();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma venda!");
            }
        }

        public override string GetRegisterType()
        {
            return "Cadastro de vendas";
        }

        public override void Update()
        {
            UpdateComboBox();

            Sale selectedSale = _saleControl.GetSelectedSale();
            //selectedSale.Products = _saleService.GetProductsFromSales(selectedSale.Id);

            if (selectedSale != null)
            {
                SaleRegisterDialog dialog = new SaleRegisterDialog(selectedSale, _products);
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _saleService.Update(selectedSale);
                }

                ListSales();
            }
            else
            {
                MessageBox.Show("Selecione uma venda!");
            }
        }

        private void UpdateComboBox()
        {
            _products = _productService.GetAll();
        }

        public override UserControl LoadLinsting()
        {
            if (_saleControl == null)
                _saleControl = new SaleControl();

            return _saleControl;
        }
    }
}
