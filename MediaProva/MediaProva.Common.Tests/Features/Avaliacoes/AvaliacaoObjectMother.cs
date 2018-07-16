using MediaProva.Domain.Features.Alunos;
using MediaProva.Domain.Features.Avaliacoes;
using MediaProva.Domain.Features.Resultados;
using System;
using System.Collections.Generic;

namespace MediaProva.Common.Tests.Features.Avaliacoes
{
    public static class AvaliacaoObjectMother
    {
        public static Avaliacao CriarAvaliacaoValida()
        {
            var avaliacao = new Avaliacao();
            
            avaliacao.Assunto = "ORM";
            avaliacao.Data = DateTime.Now;
            avaliacao.Resultados = new List<Resultado>();

            return avaliacao;
        }

        public static Avaliacao CriarAvaliacaoValidaComResultado()
        {
            var avaliacao = new Avaliacao();

            avaliacao.Assunto = "ORM";
            avaliacao.Data = DateTime.Now;
            avaliacao.Resultados = new List<Resultado> { new Resultado(new Aluno()) };

            return avaliacao;
        }
    }
}
