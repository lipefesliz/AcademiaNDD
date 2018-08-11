using Prova2.Applications;
using Prova2.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prova2.WinApp
{
    public partial class Rosangela : Form
    {
        public Rosangela()
        {
            InitializeComponent();

            ClearFields();
            ListBooks();
            ListOrders();
        }

        private Book _book = new Book();
        private Book _bookSelected = new Book();
        private BookService _bookService = new BookService();

        private Order _order = new Order();
        private OrderService _orderService = new OrderService();


        private void btnSave_Click(object sender, EventArgs e)
        {
            Book objBook = new Book();

            try
            {
                FormBookToObject();

                if (_book.Id == 0)
                {
                    objBook = _bookService.AddBook(_book);
                }
                else
                {
                    objBook = _bookService.UpdateBook(_book);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (objBook.Ex == false)
            {
                ClearFields();
                DisableButtons();
            }
            else
            {
                DisableButtons();
            }
        }

        private void FormBookToObject()
        {
            //Validação do componente txtBox para numérico
            if (!String.IsNullOrEmpty(txtVolume.Text) && !char.IsNumber(txtVolume.Text.ToCharArray()[0]))
            {
                throw new Exception("O valor deve ser numérico!");
            }
            if (String.IsNullOrEmpty(txtVolume.Text))
            {
                throw new Exception("O Volume deve ser numérico e um campo válido!");
            }
            _book.Title = txtTitle.Text;
            _book.Theme = txtTheme.Text;
            _book.Autor = txtAutor.Text;
            _book.Volume = Convert.ToInt32(txtVolume.Text);
            _book.IsAvailable = cbIsAvailable.Checked ? true : false; //Operador ternário
            _book.DatePublication = dtpDatePublication.Value;
        }

        private void FormOrderToObject()
        {
            _order.Customer = txtCustomer.Text;
            _order.Book = _bookSelected;
            _order.ReturnDate = dtpReturnDate.Value;
        }

        private void ClearFields()
        {
            _book = new Book();

            txtId.Text = "0";
            txtTitle.Clear();
            txtTheme.Clear();
            txtAutor.Clear();
            txtVolume.Clear();
            dtpDatePublication.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now;
            cbIsAvailable.Checked = false;

            _order = new Order();
            txtCustomer.Clear();
            cmbBooks.SelectedIndex = -1;
            //numQty.ResetText();

            ListOrders();
            ListBooks();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            _book = lbBooks.SelectedItem as Book;

            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tabRosangela.SelectedIndex = 0;
            txtId.Text = _book.Id.ToString();
            txtTitle.Text = _book.Title;
            txtTheme.Text = _book.Theme;
            txtAutor.Text = _book.Autor;
            txtVolume.Text = _book.Volume.ToString();
            cbIsAvailable.Checked = _book.IsAvailable ? true : false;
            dtpDatePublication.Value = _book.DatePublication;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_book != null)
            {
                var message = MessageBox.Show("Deseja excluir o produto " + _book.Title + "?", "Atenção",
                    MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    _bookService.DeleteBook(_book);

                    ListBooks();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para excluir!");
            }

            DisableButtons();
        }

        private void ListBooks()
        {
            lbBooks.Items.Clear();
            cmbBooks.Items.Clear();

            var list = _bookService.GetAllBooks();

            foreach (var item in list)
            {
                lbBooks.Items.Add(item);

                if (item.IsAvailable)
                {
                    cmbBooks.Items.Add(item);
                }
            }
        }

        private void ListOrders()
        {
            lbOrders.Items.Clear();

            var list = _orderService.GetAllOrders();

            foreach (var item in list)
            {
                lbOrders.Items.Add(item);
            }
        }

        private void cmbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bookSelected = cmbBooks.SelectedItem as Book;
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            Order obj = new Order();
            try
            {
                if (_order.Id == 0)
                {
                    FormOrderToObject();

                    obj = _orderService.AddOrder(_order);
                }
                else
                {
                    FormOrderToObject();

                    _orderService.UpdateOrder(_order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return; // precisa deste return para nao limpar os campos ja informados
            }

            if (obj.Ex == false)
            {
                ClearFields();
                DisableButtons();
            } else
            {
                DisableButtons();
            }
        }

        private void btnClearOrders_Click(object sender, EventArgs e)
        {
            ClearFields();
            DisableButtons();
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            txtCustomer.Text = _order.Customer;

            dtpReturnDate.Value = _order.ReturnDate;

            cmbBooks.SelectedItem = _order.Book;

            ListOrders();

            DisableButtons();
        }

        private void lbOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            _order = lbOrders.SelectedItem as Order;

            btnDeleteOrder.Enabled = true;
            btnEditOrder.Enabled = true;
            btnTax.Enabled = true;
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (_order != null)
            {
                var message = MessageBox.Show("Deseja excluir o empréstimo " + _order.Customer + "?", "Atenção",
                    MessageBoxButtons.YesNo);

                if (message == DialogResult.Yes)
                {
                    _orderService.DeleteOrder(_order);

                    ListOrders();
                    ClearFields();
                    DisableButtons();
                    
                }
            }
            else
            {
                MessageBox.Show("Selecione um empréstimo para excluir!");
            }
        }

        private void DisableButtons()
        {
            btnDeleteOrder.Enabled = false;
            btnEditOrder.Enabled = false;
            btnTax.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void btnTax_Click(object sender, EventArgs e)
        {

            _order.Tax = _order.GetTax(_order);

            MessageBox.Show("O lucro do produto selecionado é de: " + _order.Tax);
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            _bookService.BookPdfCreator();
        }

        private void btnReportOrder_Click(object sender, EventArgs e)
        {
            _orderService.OrderPdfCreator();
        }
    }
}
