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
    public class QuestoesServico
    {
        QuestaoDAO _questaoDAO = new QuestaoDAO();
        public void Adicionar (Questao questao)
        {
            try
            {
                IList<Questao> listaQuestao = GetAll();

                foreach (var item in listaQuestao)
                {
                    if (questao.Pergunta.Trim().Equals(item.Pergunta.Trim()))
                        throw new Exception("A questão já existe");
                }
                
                questao.Validacao();
                _questaoDAO.Adicionar(questao);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public IList<Questao> GetAll()
        {
            try
            {
                return _questaoDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete (Questao questao)
        {
            try
            {
                _questaoDAO.Delete(questao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Questao questao)
        {
            try
            {
                questao.Validacao();
                _questaoDAO.Editar(questao);
                IList<Questao> listaQuestao = GetAll();

                foreach (var item in listaQuestao)
                {
                    if (questao.Pergunta.Trim().Equals(item.Pergunta.Trim()))
                        throw new Exception("A questão já existe");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Questao> GetAllRandom(Teste teste, Materia materia,Questao questao)
        {
            try
            {
                var List = _questaoDAO.GetAllRandom(teste,materia,questao);
                return List;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       

    }
}
