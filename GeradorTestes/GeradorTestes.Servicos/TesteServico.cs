using GeradorTestes.Domain;
using GeradorTestes.Infra;
using GeradorTestes.Infra.PDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Servicos
{
    public class TesteServico
    {
        TesteDAO testeDAO = new TesteDAO();
        QuestaoDAO questaoDAO = new QuestaoDAO();
        public void GerarTeste(Teste teste, Materia materia, Questao questao)
        {
            try
            {
                int testeID = testeDAO.AdicionarTBTestes(teste);

                IList<Questao> questaoList = questaoDAO.GetAllRandom(teste, materia, questao);

                if (teste.QuantidadeQuestoes > questaoList.Count)
                {
                    throw new Exception("A quantidade de questões do " + questao.Bimestre + " e na Matéria " + materia.Nome + " é de " + questaoList.Count);
                }
                else
                {

                    if (questaoList.Count < 1)
                    {
                        throw new Exception("Não há nenhuma questão cadastrada nesse Bimestre e nessa matéria");
                    }
                    else
                    {

                        foreach (var item in questaoList)
                        {
                            testeDAO.AdicionarTBTestes_Questoes(Convert.ToInt32(item.ID), testeID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        public IList<Teste> GetAll()
        {
            try
            {
                return testeDAO.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Questao> GetAllTesteQuestoes(Teste teste)
        {
            try
            {
                return testeDAO.GetQuestoes(teste);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Teste testeDelete)
        {
            try
            {
                testeDAO.Delete(testeDelete);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GerarPDF(Teste teste, string caminho)
        {
            try
            {
                //testeDAO.GetQuestoes(teste);
                GerarPDFTestes.GerarPDF(teste, caminho);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}