using MediaProva.Domain.Base;
using MediaProva.Domain.Features.Alunos.Exceptions;
using MediaProva.Domain.Features.Resultados;
using System;
using System.Collections.Generic;

namespace MediaProva.Domain.Features.Alunos
{
    public class Aluno : Entity
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public virtual ICollection<Resultado> Resultados { get; set; }
        public double Media { get; internal set; }

        public static double soma = 0;

        public Aluno()
        {
            Resultados = new List<Resultado>();
        }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Nome))
                throw new NomeVazioException();

            if (Idade < 1)
                throw new IdadeInvalidaException();
        }

        private void ArredondarMedia()
        {
            double inteiro = Math.Floor(Media);
            double subtracao = Media - inteiro;

            if (subtracao < 0.35)
                Media = inteiro;
            else if (subtracao >= 0.35 && subtracao < 0.75)
                Media = inteiro + 0.5;
            else if (subtracao >= 0.75 && subtracao < 1)
                Media = inteiro + 1;
        }

        public double CalcularMedia()
        {
            if (Resultados.Count > 0)
            {
                foreach (var resultado in Resultados)
                {
                    soma += resultado.Nota;
                }

                Media = soma / Resultados.Count;

                ArredondarMedia();

                soma = 0;

                return Media;
            }

            return Media;
        }
    }
}
