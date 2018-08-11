using AndersonLiz.Agenda.Doamain;
using AndersonLiz.Agenda.Doamain.Exceptions;
using AndersonLiz.Agenda.Doamain.Features.Contatos;
using System.Collections.Generic;

namespace AndersonLiz.Agenda.App
{
    public class ContatoService
    {
        private IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public void Add(Contato entidade)
        {
            entidade.Valida();

            bool contatoEncontrado = _contatoRepository.Existe(entidade.Nome);

            if (contatoEncontrado)
                throw new NomeDuplicadoException();

            _contatoRepository.Add(entidade);
        }

        public void Update(Contato entidade)
        {
            entidade.Valida();

            bool nomeEncontrado = _contatoRepository.Existe(entidade.Id, entidade.Nome);

            if (!nomeEncontrado)
                throw new NomeDuplicadoException();

            _contatoRepository.Update(entidade);
        }

        public void Delete(Contato entidade)
        {
            if (RegistroComDependecia(entidade.Id))
                throw new DependenciaException();

            _contatoRepository.Delete(entidade.Id);
        }

        private bool RegistroComDependecia(int id)
        {
            return _contatoRepository.RegistroComDependencia(id);
        }

        public Contato SelecionaPorId(int id)
        {
            return _contatoRepository.GetById(id);
        }

        public List<Contato> SelecionaTudo()
        {
            return _contatoRepository.GetAll();
        }
    }
}
