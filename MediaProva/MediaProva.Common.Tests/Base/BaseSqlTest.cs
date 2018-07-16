using MediaProva.Common.Tests.Features.Alunos;
using MediaProva.Common.Tests.Features.Avaliacoes;
using MediaProva.Common.Tests.Features.Resultados;
using MediaProva.Infra.Data.Base;
using System.Data.Entity;

namespace MediaProva.Common.Tests.Base
{
    public class BaseSqlTest : DropCreateDatabaseAlways<MediaProvaContext>
    {
        protected override void Seed(MediaProvaContext context)
        {
            var aluno = context.Alunos.Add(AlunoObjectMother.CriarAlunoValido());
            var avaliacao = context.Avaliacoes.Add(AvaliacaoObjectMother.CriarAvaliacaoValida());
            context.Resultados.Add(ResultadoObjectMother.CriarResultadoValido(aluno, avaliacao));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
