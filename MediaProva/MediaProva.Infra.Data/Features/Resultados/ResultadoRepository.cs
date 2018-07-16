using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MediaProva.Domain.Features.Resultados;
using MediaProva.Infra.Data.Base;

namespace ProjetoModelo.Infra.Data.Features.Resultados
{
    public class ResultadoRepository : IResultadoRepository
    {
        MediaProvaContext _contexto;

        public ResultadoRepository(MediaProvaContext contexto)
        {
            _contexto = contexto;
        }

        public Resultado Add(Resultado resultado)
        {
            resultado = _contexto.Resultados.Add(resultado);

            _contexto.SaveChanges();

            return resultado;
        }

        public void Delete(Resultado resultado)
        {
            _contexto.Resultados.Remove(resultado);

            _contexto.SaveChanges();
        }

        public Resultado Get(long id)
        {
            //return _contexto.Resultados.Where(r => r.Id == id).Include(r => r.Aluno).FirstOrDefault();
            return _contexto.Resultados.Find(id);
        }

        public IEnumerable<Resultado> GetAll()
        {
            return _contexto.Resultados;
        }

        public Resultado Update(Resultado resultado)
        {
            _contexto.Entry(resultado).State = EntityState.Modified;

            _contexto.SaveChanges();

            return resultado;
        }
    }
}
