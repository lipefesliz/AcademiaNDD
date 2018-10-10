using MF6.Domain.Exceptions;
using MF6.Domain.Features.Impressoras;
using System.Linq;

namespace MF6.Application.Features.Impressoras
{
    public class ImpressoraService : IImpressoraService
    {
        private readonly IImpressoraRepository _impressoraRepository;

        public ImpressoraService(IImpressoraRepository impressoraRepository)
        {
            _impressoraRepository = impressoraRepository;
        }

        public long Add(Impressora impressora)
        {
            var novaImpressora = _impressoraRepository.Add(impressora);

            return novaImpressora.Id;
        }

        public IQueryable<Impressora> GetAll()
        {
            return _impressoraRepository.GetAll();
        }

        public Impressora GetById(long id)
        {
            var impressora = _impressoraRepository.GetbyId(id);

            return impressora;
        }

        public bool Remove(Impressora impressora)
        {
            return _impressoraRepository.Remove(impressora.Id);
        }

        public bool Update(Impressora impressora)
        {
            var impressoraDb = _impressoraRepository.GetbyId(impressora.Id) ?? throw new NotFoundException();
            impressoraDb.EmUso = impressora.EmUso;
            impressoraDb.Marca = impressora.Marca;
            impressoraDb.Rede = impressora.Rede;

            return _impressoraRepository.Update(impressoraDb);
        }


        public bool UpdateNivel(Nivelador nivelador)
        {
            var impressoraDb = _impressoraRepository.GetbyId(nivelador.Impressora.Id) ?? throw new NotFoundException();

            if (nivelador.Operacao == TipoOperacao.ADICAO)
                impressoraDb.TonerColorido.AumentarNivel(nivelador.Quantidade);
            else
                impressoraDb.TonerColorido.DiminuirNivel(nivelador.Quantidade);

            return _impressoraRepository.Update(impressoraDb);
        }
    }
}
