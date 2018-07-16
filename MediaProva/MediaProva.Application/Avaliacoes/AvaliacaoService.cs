using System.Collections.Generic;
using MediaProva.Domain.Exceptions;
using MediaProva.Domain.Features.Avaliacoes;
using ProjetoModelo.Application.Avaliacoes;

namespace MediaProva.Application.Avaliacoes
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private IAvaliacaoRepository _repositorio;

        public AvaliacaoService(IAvaliacaoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public Avaliacao Add(Avaliacao avaliacao)
        {
            avaliacao.Validate();

            return _repositorio.Add(avaliacao);
        }

        public void Delete(Avaliacao avaliacao)
        {
            if (avaliacao.Id < 1)
                throw new IdentifierUndefinedException();

            if (avaliacao.Resultados.Count > 0)
                throw new IsTiedException();

            _repositorio.Delete(avaliacao);
        }

        public Avaliacao Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _repositorio.Get(id);
        }

        public IEnumerable<Avaliacao> GetAll()
        {
            return _repositorio.GetAll();
        }

        public Avaliacao Update(Avaliacao avaliacao)
        {
            if (avaliacao.Id < 1)
                throw new IdentifierUndefinedException();

            avaliacao.Validate();

            return _repositorio.Update(avaliacao);
        }
    }
}
