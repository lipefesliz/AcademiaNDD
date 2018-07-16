using MediaProva.Common.Tests.Features.Alunos;
using MediaProva.Common.Tests.Features.Avaliacoes;
using MediaProva.Domain.Features.Alunos;
using MediaProva.Domain.Features.Avaliacoes;
using MediaProva.Domain.Features.Resultados;

namespace MediaProva.Common.Tests.Features.Resultados
{
    public static class ResultadoObjectMother
    {
        public static Resultado CriarResultadoValido()
        {
            var aluno = AlunoObjectMother.CriarAlunoValido();
            var resultado = new Resultado(aluno);

            resultado.Nota = 8;
            resultado.AtribuirResultado();
            resultado.Avaliacao = AvaliacaoObjectMother.CriarAvaliacaoValida();

            return resultado;
        }

        public static Resultado CriarResultadoValido(Aluno aluno, Avaliacao avaliacao)
        {
            var resultado = new Resultado(aluno);

            resultado.Nota = 8;
            resultado.AtribuirResultado();
            resultado.Avaliacao = avaliacao;

            return resultado;
        }
    }
}
