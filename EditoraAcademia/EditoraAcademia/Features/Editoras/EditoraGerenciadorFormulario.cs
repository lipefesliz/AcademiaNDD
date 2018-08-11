using EditoraAcademia.App;
using EditoraAcademia.Domain.Features.Editoras;
using EditoraAcademia.Domain.Features.Livros;
using EditoraAcademia.WinApp.Features;
using EditoraAcademia.WinApp.Features.Editoras;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EditoraAcademia.Features.Editoras
{
    public class EditoraGerenciadorFormulario : GerenciadorFormulario
    {
        private readonly EditoraService _editoraService;
        private readonly LivroService _livroService;

        private EditoraControl _editoraControl;

        private IList<Livro> _livros;

        public EditoraGerenciadorFormulario(EditoraService editoraService, LivroService livroService)
        {
            _editoraService = editoraService;
            _livroService = livroService;
        }

        public override void Add()
        {
            AtualizaComboBox();

            CadastroEditoraDialog dialog = new CadastroEditoraDialog(_livros);
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _editoraService.Add(dialog.Editora);
                ListarEditoras();
            }
        }

        private void ListarEditoras()
        {
            IList<Editora> editora = _editoraService.SelecionaTudo();

            _editoraControl.PopularListagemEditoras(editora);
        }

        public override void AtualizarLista()
        {
            ListarEditoras();
        }

        public override UserControl CarregarListagem()
        {
            if (_editoraControl == null)
                _editoraControl = new EditoraControl();

            return _editoraControl;
        }

        public override void Delete()
        {
            Editora editoraSelecionada = _editoraControl.ObtemEditoraSelecionada();

            if (editoraSelecionada != null)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir a editora "
                    + editoraSelecionada.Id, "Excluir editora",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        _editoraService.Delete(editoraSelecionada);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    ListarEditoras();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma editora!");
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de editoras";
        }

        public override void Update()
        {
            AtualizaComboBox();

            Editora editoraSelecionada = _editoraControl.ObtemEditoraSelecionada();
            editoraSelecionada.Livros = _editoraService.GetLivrosFromEditoras(editoraSelecionada.Id);

            if (editoraSelecionada != null)
            {
                CadastroEditoraDialog dialog = new CadastroEditoraDialog(editoraSelecionada, _livros);
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _editoraService.Update(editoraSelecionada);
                }

                ListarEditoras();
            }
            else
            {
                MessageBox.Show("Selecione um editora!");
            }
        }

        private void AtualizaComboBox()
        {
            _livros = _livroService.SelecionaTudo();
        }
    }
}
