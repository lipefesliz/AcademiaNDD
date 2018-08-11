using AndersonLiz.Agenda.App;
using AndersonLiz.Agenda.Doamain;
using AndersonLiz.Agenda.Doamain.Features.Compromissos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AndersonLiz.Agenda.WinApp.Features.Compromissos
{
    public class CompromissoGerenciadorFormulario : GerenciadorFormulario
    {
        private readonly CompromissoService _compromissoService;
        private readonly ContatoService _contatoService;

        private CompromissoControl _compromissoControl;

        private IList<Contato> _contatos;

        public CompromissoGerenciadorFormulario(CompromissoService compromissoService, ContatoService contatoService)
        {
            _compromissoService = compromissoService;
            _contatoService = contatoService;
        }

        public override void Add()
        {
            AtualizaComboBox();

            CadastroCompromissoDialog dialog = new CadastroCompromissoDialog(_contatos);
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _compromissoService.Add(dialog.Compromisso);
                ListarCompromissos();
            }
        }

        private void ListarCompromissos()
        {
            IList<Compromisso> compromisso = _compromissoService.SelecionaTudo();

            _compromissoControl.PopularListagemComproissos(compromisso);
        }

        public override void AtualizarLista()
        {
            ListarCompromissos();
        }

        public override UserControl CarregarListagem()
        {
            if (_compromissoControl == null)
                _compromissoControl = new CompromissoControl();

            return _compromissoControl;
        }

        public override void Delete()
        {
            Compromisso compromissoSelecionado = _compromissoControl.ObtemCompromissoSelecionado();

            if (compromissoSelecionado != null)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir o compromisso "
                    + compromissoSelecionado.Id, "Excluir compromisso",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        _compromissoService.Delete(compromissoSelecionado);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    ListarCompromissos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um contato!");
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de compromissos";
        }

        public override void Update()
        {
            AtualizaComboBox();

            Compromisso compromissoSelecionado = _compromissoControl.ObtemCompromissoSelecionado();
            compromissoSelecionado.Contatos = _compromissoService.GetContatosFromCompromissos(compromissoSelecionado.Id);

            if (compromissoSelecionado != null)
            {
                CadastroCompromissoDialog dialog = new CadastroCompromissoDialog(compromissoSelecionado, _contatos);
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _compromissoService.Update(compromissoSelecionado);
                }

                ListarCompromissos();
            }
            else
            {
                MessageBox.Show("Selecione um compromisso!");
            }
        }

        private void AtualizaComboBox()
        {
            _contatos = _contatoService.SelecionaTudo();
        }
    }
}
