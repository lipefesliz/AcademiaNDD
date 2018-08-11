using Prova2.Domain;
using Prova2.Infra.Data;
using Prova2.Infra.PDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Prova2.Applications
{
    public class OrderService
    {
        public OrderDAO _orderDAO = new OrderDAO();
        public BookReport _bookReport = new BookReport();

        public OrderService()
        {
        }

        public Order AddOrder(Order order)
        {
            try
            {
                order.Validate(); //Valida o emprestimo

                order = _orderDAO.Add(order);
                order.Ex = false;
            }
            catch (Exception e)
            {
                order.Ex = true;
                throw new Exception(e.Message);
            }

            return order;

        }

        public Order UpdateOrder(Order order)
        {
            try
            {
                order.Validate(); //Valida o venda

                order = _orderDAO.Update(order);
                order.Ex = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                order.Ex = true;
            }

            return order;
        }

        public Order GetOrder(int id)
        {
            try
            {
                return _orderDAO.GetById(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw new Exception(e.Message);
            }
        }

        public IList<Order> GetAllOrders()
        {
            try
            {
                return _orderDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteOrder(Order order)
        {
            try
            {
                return _orderDAO.Delete(order.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool OrderPdfCreator()
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Pdf File|*.pdf";
            saveFile.Title = "Save your PDF File";
            saveFile.ShowDialog();

            var list = GetAllOrders();
            string items = "";

            foreach (var item in list)
            {
                items += "Cliente: " + item.Customer + "\n";
                items += "Data de Retorno: " + item.ReturnDate.Day + "\n";
                items += "Livro: " + item.Book.Title + "\n";
                items += "\n";
            }

            if (saveFile.FileName != "")
            {
                _bookReport.GeneratePdf(saveFile.FileName, items);
            }

            return true;
        }
    }
}