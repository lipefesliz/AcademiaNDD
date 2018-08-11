using AndersonLiz.Agenda.App;
using AndersonLiz.Agenda.Doamain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AndersonLiz.Agenda.WinApp.Features.Contatos
{
    public class ContatoGerenciadorFormulario : GerenciadorFormulario
    {
        private readonly ContatoService _contatoService;

        private ContatoControl _contatoControl;

        public ContatoGerenciadorFormulario(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public override void Add()
        {
            CadastroContatoDialog dialog = new CadastroContatoDialog();

            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _contatoService.Add(dialog.Contato);
                ListarContatos();
            }
        }

        private void ListarContatos()
        {
            IList<Contato> contato = _contatoService.SelecionaTudo();

            _contatoControl.PopularListagemContatos(contato);
        }

        public override void AtualizarLista()
        {
            ListarContatos();
        }

        public override UserControl CarregarListagem()
        {
            if (_contatoControl == null)
                _contatoControl = new ContatoControl();

            return _contatoControl;
        }

        public override void Update()
        {
            Contato contatoSelecionado = _contatoControl.ObtemContatoSelecionado();

            if (contatoSelecionado != null)
            {
                CadastroContatoDialog dialog = new CadastroContatoDialog(contatoSelecionado);
                DialogResult resultado = dialog.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _contatoService.Update(contatoSelecionado);
                }

                ListarContatos();
            }
            else
            {
                MessageBox.Show("Selecione um contato!");
            }
        }

        public override void Delete()
        {
            Contato contatoSelecionado = _contatoControl.ObtemContatoSelecionado();

            if (contatoSelecionado != null)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir o contato "
                    + contatoSelecionado.Nome, "Excluir contato",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        _contatoService.Delete(contatoSelecionado);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }

                    ListarContatos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um contato!");
            }
        }

        public override string ObtemTipoCadastro()
        {
            return "Cadastro de contatos";
        }
    }
}
