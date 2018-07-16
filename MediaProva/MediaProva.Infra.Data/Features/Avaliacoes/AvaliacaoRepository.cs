using System.Collections.Generic;
using System.Data.Entity;
using MediaProva.Domain.Features.Avaliacoes;
using MediaProva.Infra.Data.Base;

namespace MediaProva.Infra.Data.Features.Avaliacoes
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        MediaProvaContext _contexto;

        public AvaliacaoRepository(MediaProvaContext contexto)
        {
            _contexto = contexto;
        }

        public Avaliacao Add(Avaliacao avaliacao)
        {
            avaliacao = _contexto.Avaliacoes.Add(avaliacao);

            _contexto.SaveChanges();

            return avaliacao;
        }

        public void Delete(Avaliacao avaliacao)
        {
            _contexto.Avaliacoes.Remove(avaliacao);

            _contexto.SaveChanges();
        }

        public Avaliacao Get(long id)
        {
            return _contexto.Avaliacoes.Find(id);
        }

        public IEnumerable<Avaliacao> GetAll()
        {
            return _contexto.Avaliacoes;
        }

        public Avaliacao Update(Avaliacao avaliacao)
        {
            _contexto.Entry(avaliacao).State = EntityState.Modified;

            _contexto.SaveChanges();

            return avaliacao;
        }
    }
}
