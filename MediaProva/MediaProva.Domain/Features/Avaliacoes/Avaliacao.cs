using MediaProva.Domain.Base;
using MediaProva.Domain.Features.Avaliacoes.Exceptions;
using MediaProva.Domain.Features.Resultados;
using System;
using System.Collections.Generic;

namespace MediaProva.Domain.Features.Avaliacoes
{
    public class Avaliacao : Entity
    {
        public string Assunto { get; set; }
        public DateTime Data { get; set; }
        public virtual ICollection<Resultado> Resultados { get; set; }

        public Avaliacao()
        {
            Resultados = new List<Resultado>();
        }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Assunto))
                throw new AssuntoVazioException();

            if (Resultados.Count < 1)
                throw new ResultadoVazioException();
        }
    }
}
