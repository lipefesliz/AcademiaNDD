using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado.WinApp
{
    public abstract class GerenciadorFormulario
    {
        public abstract void Adicionar();

        public abstract void Editar();

        public abstract void Excluir();

        public abstract void BuscarPorNome(string nome);

        public abstract void AtualizarLista();

        public abstract UserControl ObterTipoUserControl();

        public abstract string ObtemTipoCadastro();

        public virtual string btnCad { get => "Cadastrar"; }
        public virtual string btnEdit { get => "Editar"; }
        public virtual string btnDel { get => "Excluir"; }
        public virtual string btnFiltro { get => "Buscar"; }
    }
}
