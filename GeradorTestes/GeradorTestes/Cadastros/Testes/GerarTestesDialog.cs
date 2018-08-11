using GeradorTestes.Domain;
using GeradorTestes.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorTestes.Cadastros.Testes
{
    public partial class GerarTestesDialog : Form
    {

        MateriaServico _materiaServico = new MateriaServico();
        QuestoesServico _questoesServico = new QuestoesServico();
        TesteServico _testeServico = new TesteServico();
        public GerarTestesDialog()
        {
            InitializeComponent();
            InsertBimestreInComomBox();
        }

        private void btnGerarTeste_Click(object sender, EventArgs e)
        {

            try
            {
                VerificaCampos();
                var materia = new Materia();
                materia.Nome = cmbMateria.SelectedItem.ToString();
                var questao = new Questao();
                questao.Bimestre = cmbBimestre.SelectedItem.ToString();
                var teste = new Teste();
                teste.QuantidadeQuestoes = Convert.ToInt32(quantidadeQuestoes.Value);
                teste.dataGeracao = DateTime.Now;
                teste.Descricao = "Descrição";
                var list = _questoesServico.GetAllRandom(teste, materia, questao);


                _testeServico.GerarTeste(teste, materia, questao);
                MessageBox.Show("Adicionado com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void VerificaCampos()
        {
            if (cmbBimestre.SelectedItem == null)
            {
                throw new Exception("Selecione um Bimestre");
            }

            if (cmbMateria.SelectedItem == null)
            {
                throw new Exception("Selecione uma Matéria");
            }

            if (quantidadeQuestoes.Value <= 0)
            {
                throw new Exception("A quantidade de questões deve ser maior que zero");
            }
        }
        public void InsertSerieInComomBox(IList<Serie> serie)
        {

            foreach (var item in serie)
            {
                cmbSerie.Items.Add(item);
            }
        }

        public void InsertDisciplinaInComomBox(IList<Disciplina> disciplina)
        {

            foreach (var item in disciplina)
            {
                cmbDisciplina.Items.Add(item);
            }
        }

        public void InsertMateriaInComomBox(IList<Materia> materia)
        {

            foreach (var item in materia)
            {
                cmbMateria.Items.Add(item);
            }
        }

        public void InsertBimestreInComomBox()
        {

            cmbBimestre.Items.Add("1º Bimestre");
            cmbBimestre.Items.Add("2º Bimestre");
            cmbBimestre.Items.Add("3º Bimestre");
            cmbBimestre.Items.Add("4º Bimestre");
        }

        private void cmbSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisciplina.SelectedItem == null)
            {
                AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(cmbSerie.SelectedItem as Serie, new Disciplina { Nome = "" }));
            }
            else
            {
                AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(cmbSerie.SelectedItem as Serie, cmbDisciplina.SelectedItem as Disciplina));
            }

        }

        private void AtualizaLista(IList<Materia> listaMateria)
        {
            cmbMateria.Items.Clear();
            foreach (var item in listaMateria)
            {
                cmbMateria.Items.Add(item);
            }
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSerie.SelectedItem == null)
            {
                AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(new Serie { Nome = "" }, cmbDisciplina.SelectedItem as Disciplina));
            }
            else
            {
                AtualizaLista(_materiaServico.GetMateriaBySerieAndDisciplina(cmbSerie.SelectedItem as Serie, cmbDisciplina.SelectedItem as Disciplina));
            }
        }

    }
}
