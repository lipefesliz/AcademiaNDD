using System.Windows.Forms;
using System.Collections.Generic;
using AndersonLiz.Agenda.Doamain.Features.Contatos;
using AndersonLiz.Agenda.App;
using AndersonLiz.Agenda.Doamain;
using AndersonLiz.Agenda.Infra.Data;

namespace AndersonLiz.Agenda.WinApp.Features.Contatos
{
    public partial class ContatoControl : UserControl
    {
        private IContatoRepository _contatoRepository;
        private ContatoService _contatoService;

        public ContatoControl()
        {
            InitializeComponent();

            _contatoRepository = new ContatoRepository();
            _contatoService = new ContatoService(_contatoRepository);
        }

        public void PopularListagemContatos(IList<Contato> contatos)
        {
            listContatos.Items.Clear();

            foreach (Contato item in contatos)
            {
                listContatos.Items.Add(item);
            }
        }

        public Contato ObtemContatoSelecionado()
        {
            return (Contato)listContatos.SelectedItem;
        }
    }
}
