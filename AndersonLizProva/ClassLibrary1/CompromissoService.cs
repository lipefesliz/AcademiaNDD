using AndersonLiz.Agenda.Doamain;
using AndersonLiz.Agenda.Doamain.Exceptions;
using AndersonLiz.Agenda.Doamain.Features.Compromissos;
using System.Collections.Generic;

namespace AndersonLiz.Agenda.App
{
    public class CompromissoService
    {
        private ICompromissoRepository _compromissoRepository;

        public CompromissoService(ICompromissoRepository compromissoRepository)
        {
            _compromissoRepository = compromissoRepository;
        }

        public void Add(Compromisso entidade)
        {
            entidade.Valida();

            bool compromissoEncontrado = _compromissoRepository.Existe(entidade.Inicio);

            if (compromissoEncontrado)
                throw new HorarioDuplicadoException();

            _compromissoRepository.Add(entidade);
        }

        public void Update(Compromisso entidade)
        {
            entidade.Valida();

            bool compromissoEncontrado = _compromissoRepository.Existe(entidade.Id, entidade.Inicio);

            if (!compromissoEncontrado)
                throw new HorarioDuplicadoException();

            _compromissoRepository.Update(entidade);
        }

        public void Delete(Compromisso entidade)
        {
            _compromissoRepository.Delete(entidade.Id);
        }

        public Compromisso SelecionaPorId(int id)
        {
            return _compromissoRepository.GetById(id);
        }

        public List<Compromisso> SelecionaTudo()
        {
            return _compromissoRepository.GetAll();
        }

        public IList<Contato> GetContatosFromCompromissos(int id)
        {
            return _compromissoRepository.GetContatosFromCompromissos(id);
        }
    }
}
