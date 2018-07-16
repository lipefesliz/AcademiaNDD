using System.Collections.Generic;
using MediaProva.Domain.Exceptions;
using MediaProva.Domain.Features.Resultados;

namespace MediaProva.Application.Resultados
{
    public class ResultadoService : IResultadoService
    {
        private IResultadoRepository _repositorio;

        public ResultadoService(IResultadoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public Resultado Add(Resultado resultado)
        {
            resultado.Validate();

            return _repositorio.Add(resultado);
        }

        public void Delete(Resultado resultado)
        {
            if (resultado.Id < 1)
                throw new IdentifierUndefinedException();

            _repositorio.Delete(resultado);
        }

        public Resultado Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _repositorio.Get(id);
        }

        public IEnumerable<Resultado> GetAll()
        {
            return _repositorio.GetAll();
        }

        public Resultado Update(Resultado resultado)
        {
            if (resultado.Id < 1)
                throw new IdentifierUndefinedException();

            resultado.Validate();

            return _repositorio.Update(resultado);
        }
    }
}
