using Mercado.Serviço;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercado.Dominio.Interfaces;

namespace Mercado.WinApp.Cadastros
{
    public class ProdutoGerenciadorFormulario : GerenciadorFormulario
    {
        ProdutoService _produtoService;
        ProdutoUserControl _produtoUserControl;
        private IProdutoRepository _repository;

        public ProdutoGerenciadorFormulario(IProdutoRepository repository)
        {
            _repository = repository;
            _produtoService = new ProdutoService(_repository);
        }

        public override void Adicionar()
        {
            CadastroProdutoDialog _cadastroProdutoDialog = new CadastroProdutoDialog(_produtoService, "Cadastro de produtos", null);

            _cadastroProdutoDialog.ShowDialog();

            AtualizarLista();
        }
        
        public override void Editar()
        {
            if (_produtoUserControl.GetSelect() != null)
            {

                CadastroProdutoDialog _editarProdutoDialog = new CadastroProdutoDialog(_produtoService, "Edição do produto", _produtoUserControl.GetSelect());
                _editarProdutoDialog.ShowDialog();
                AtualizarLista();
            }
            else
            {
                MessageBox.Show("Você precisa selecionar um produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public override void Excluir()
        {
            if (_produtoUserControl.GetSelect() != null) {
                try
                {
                    if (MessageBox.Show("Tem certeza que deseja excluir?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _produtoService.Delete(_produtoUserControl.GetSelect());
                        MessageBox.Show("Exluído com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                AtualizarLista();
            }
            else
            {
                MessageBox.Show("Você precisa selecionar um produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de Produtos";
        }

        public override UserControl ObterTipoUserControl()
        {
            return _produtoUserControl = new ProdutoUserControl(_repository);
        }

        public override void BuscarPorNome(string nome)
        {
            _produtoUserControl.BuscarPorNome(nome);
        }

        public override void AtualizarLista()
        {
            _produtoUserControl.CarregarLista();
        }
    }
}
