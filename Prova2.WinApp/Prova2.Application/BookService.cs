using Prova2.Domain;
using Prova2.Infra.Data;
using Prova2.Infra.PDF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prova2.Applications
{
    public class BookService
    {
        public BookDAO _bookDAO = new BookDAO();
        public BookReport _bookReport = new BookReport();

        public BookService()
        {
        }

        public Book AddBook(Book book)
        {
            try
            {
                book.Validate(); //Valida o produto

                book = _bookDAO.Add(book);

                book.Ex = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                book.Ex = true;
            }

            return book;
        }

        public Book UpdateBook(Book book)
        {
            try
            {
                book.Validate(); //Valida o produto.

                book = _bookDAO.Update(book);
                book.Ex = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                book.Ex = true;
            }

            return book;
        }

        public Book GetBook(int id)
        {
            try
            {
                return _bookDAO.GetById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Book> GetAllBooks()
        {
            try
            {
                return _bookDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int DeleteBook(Book book)
        {
            try
            {
                return _bookDAO.Delete(book.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool BookPdfCreator()
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Pdf File|*.pdf";
            saveFile.Title = "Save your PDF File";
            saveFile.ShowDialog();

            var list = GetAllBooks();
            string items = "";

            foreach (var item in list)
            {
                items += "Título: " + item.Title + "\n";
                items += "Tema: " + item.Theme + "\n";
                items += "Autor: " + item.Autor + "\n";
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
