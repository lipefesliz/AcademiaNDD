using MediaProva.Domain.Base;
using MediaProva.Domain.Features.Alunos;
using MediaProva.Domain.Features.Avaliacoes;
using MediaProva.Domain.Features.Resultados.Exceptions;

namespace MediaProva.Domain.Features.Resultados
{
    public class Resultado : Entity
    {
        public double Nota { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }
        public virtual Aluno Aluno { get; set; }

        private Resultado()
        {
        }

        public Resultado(Aluno aluno)
        {
            Aluno = aluno;
        }

        public void AtribuirResultado()
        {
            Aluno.Resultados.Add(this);
        }

        public override void Validate()
        {
            if (Avaliacao == null)
                throw new AvaliacaoNulaException();

            if (Aluno == null)
                throw new AlunoNuloException();
        }
    }
}
