using FluentAssertions;
using MediaProva.Common.Tests.Features.Alunos;
using MediaProva.Domain.Features.Alunos;
using MediaProva.Domain.Features.Resultados;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaProva.Domain.Tests.Features.Alunos
{
    [TestFixture]
    public class AlunoDomainTestes
    {
        Aluno _aluno;
        
        [SetUp]
        public void SetUp()
        {
            _aluno = AlunoObjectMother.CriarAlunoComDuasNotas();
        }

        /*TESTES CAMINHO FELIZ*/
        //[Test]
        public void Teste_Aluno_Domain_Criar_Aluno_Nao_Deve_Jogar_Excecao()
        {
            Action action = _aluno.Validate;

            action.Should().NotThrow<Exception>();
        }

        [Test]
        public void Teste_Aluno_Domain_Calcular_Media_Nao_Deve_Jogar_Excecao()
        {
            //Cenario
            var media = (_aluno.Resultados.First().Nota + _aluno.Resultados.Last().Nota) / 2;

            //Acao
            _aluno.CalcularMedia();

            //Verificacao
            _aluno.Media.Should().Be(media);
        }

        [Test]
        public void Teste_Aluno_Domain_Calcular_Media_Deve_Arredondar_Para_Baixo()
        {
            //Cenario
            _aluno.Resultados = new List<Resultado> { new Resultado(null) { Nota =  8.3 }, new Resultado(null) { Nota = 8 } };

            var media = (_aluno.Resultados.First().Nota + _aluno.Resultados.Last().Nota) / 2;
            media = Math.Floor(media);

            //Acao
            _aluno.CalcularMedia();

            //Verificacao
            _aluno.Media.Should().Be(media);
        }

        [Test]
        public void Teste_Aluno_Domain_Calcular_Media_Deve_Arredondar_Para_Cima()
        {
            //Cenario
            _aluno.Resultados = new List<Resultado> { new Resultado(null) { Nota = 8.8 }, new Resultado(null) { Nota = 8.8 } };

            var media = (_aluno.Resultados.First().Nota + _aluno.Resultados.Last().Nota) / 2;
            media = Math.Ceiling(media);

            //Acao
            _aluno.CalcularMedia();

            //Verificacao
            _aluno.Media.Should().Be(media);
        }

        [Test]
        public void Teste_Aluno_Domain_Calcular_Media_Deve_Arredondar_Para_Baixo_Mais_Zero_Virgula_Cinco()
        {
            //Cenario
            _aluno.Resultados = new List<Resultado> { new Resultado(null) { Nota = 8.8 }, new Resultado(null) { Nota = 8 } };

            var media = (_aluno.Resultados.First().Nota + _aluno.Resultados.Last().Nota) / 2;
            media = Math.Floor(media) + 0.5;

            //Acao
            _aluno.CalcularMedia();

            //Verificacao
            _aluno.Media.Should().Be(media);
        }
    }
}
