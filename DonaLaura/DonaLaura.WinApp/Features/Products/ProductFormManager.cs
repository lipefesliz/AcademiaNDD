﻿using DonaLaura.Applications.Features;
using DonaLaura.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DonaLaura.WinApp.Features.Products
{
    public class ProductFormManager : FormManager
    {
        private readonly ProductService _productService;
        private ProductRegisterDialog dialog;
        private ProductControl _productControl;

        public ProductFormManager(ProductService productService)
        {
            _productService = productService;
        }

        public override void Add()
        {
            dialog = new ProductRegisterDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _productService.Add(dialog.Product);
                ListProducts();
            }
        }

        public override void Update()
        {
            Product productSelecionado = _productControl.GetSelectedProduct();

            if (productSelecionado != null)
            {
                dialog = new ProductRegisterDialog(productSelecionado);
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _productService.Update(productSelecionado);
                    ListProducts();
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto!");
            }
        }

        private void ListProducts()
        {
            IList<Product> product = _productService.GetAll();

            _productControl.PopulateProductsListing(product);
        }

        public override void Delete()
        {
            Product selectedProduct = _productControl.GetSelectedProduct();

            if (selectedProduct != null)
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir o produto "
                    + selectedProduct.Name, "Excluir produto",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        _productService.Delete(selectedProduct);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    ListProducts();
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto!");
            }
        }

        public override string GetRegisterType()
        {
            return "Cadastro de produtos";
        }

        public override UserControl LoadLinsting()
        {
            if (_productControl == null)
                _productControl = new ProductControl();

            return _productControl;
        }

        public override void UpdateList()
        {
            ListProducts();
        }
    }
}
