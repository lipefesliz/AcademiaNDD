using EditoraAcademia.Domain.Features.Livros;
using EditoraAcademia.App;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EditoraAcademia.WinApp.Features.Livros
{
    public class LilvroGerenciadorFormulario : GerenciadorFormulario
    {
        private readonly LivroService _livroService;

        private LivroControl _livroControl;

        public LilvroGerenciadorFormulario(LivroService livroService)
        {
            _livroService = livroService;
        }

        public override void Add()
        {
            CadastroLivroDialog dialog = new CadastroLivroDialog();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _livroService.Add(dialog.Livro);
                ListarLivros();
            }
        }

        private void ListarLivros()
        {
            IList<Livro> livro = _livroService.SelecionaTudo();

            _livroControl.PopularListagemLivros(livro);
        }

        public override void AtualizarLista()
        {
            ListarLivros();
        }

        public override UserControl CarregarListagem()
        {
            if (_livroControl == null)
                _livroControl = new LivroControl();

            return _livroControl;
        }

        public override void Update()
        {
            Livro livroSelecionado = _livroControl.ObtemLivroSelecionado();

            if (livroSelecionado != null)
            {
                CadastroLivroDialog dialog = new CadastroLivroDialog(livroSelecionado);
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _livroService.Update(livroSelecionado);
                    ListarLivros();
                }
            }
            else
            {
                MessageBox.Show("Selecione um livro!");
            }
        }

        public override void Delete()
        {
            Livro livroSelecionado = _livroControl.ObtemLivroSelecionado();

            if (livroSelecionado != null)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir o livro "
                    + livroSelecionado.Titulo, "Excluir livro",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        _livroService.Delete(livroSelecionado);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    ListarLivros();
                }
            }
            else
            {
                MessageBox.Show("Selecione um livro!");
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de livros";
        }
    }
}
