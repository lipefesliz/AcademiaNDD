using System.Windows.Forms;

namespace AndersonLiz.Agenda.WinApp.Features
{
    public abstract class GerenciadorFormulario
    {
        public abstract void Add();

        public abstract UserControl CarregarListagem();

        public abstract string ObtemTipoCadastro();

        public abstract void Delete();

        public abstract void Update();

        public abstract void AtualizarLista();
    }
}
