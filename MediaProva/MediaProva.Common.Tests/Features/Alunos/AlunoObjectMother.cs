using MediaProva.Common.Tests.Features.Resultados;
using MediaProva.Domain.Features.Alunos;
using MediaProva.Domain.Features.Resultados;
using System.Collections.Generic;

namespace MediaProva.Common.Tests.Features.Alunos
{
    public static class AlunoObjectMother
    {
        public static Aluno CriarAlunoValido()
        {
            var aluno = new Aluno();

            aluno.Idade = 20;
            aluno.Nome = "Juca";
            aluno.Resultados = new List<Resultado>();
            aluno.CalcularMedia();

            return aluno;
        }

        public static Aluno CriarAlunoComDuasNotas()
        {
            var aluno = new Aluno();

            aluno.Idade = 20;
            aluno.Nome = "Juca";
            aluno.Resultados = new List<Resultado>
            {
                new Resultado(aluno) { Nota = 8, Aluno = aluno },
                new Resultado(aluno) { Nota = 10, Aluno = aluno },
            };
            aluno.CalcularMedia();

            return aluno;
        }
    }
}
