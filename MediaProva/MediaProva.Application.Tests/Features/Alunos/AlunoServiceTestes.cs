using FluentAssertions;
using MediaProva.Application.Alunos;
using MediaProva.Common.Tests.Features.Alunos;
using MediaProva.Domain.Features.Alunos;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaProva.Application.Tests.Features.Alunos
{
    [TestFixture]
    public class AlunoServiceTestes
    {
        Mock<IAlunoRepository> _mockRepositorio;
        AlunoService _servico;
        Aluno _aluno;

        [SetUp]
        public void SetUp()
        {
            _mockRepositorio = new Mock<IAlunoRepository>();
            _servico = new AlunoService(_mockRepositorio.Object);
            _aluno = AlunoObjectMother.CriarAlunoValido();
        }

        [Test]
        public void Aluno_Aplicacao_Add_Deve_Adicionar_Aluno()
        {
            //cenario
            _aluno.Id = 1;
            _mockRepositorio.Setup(r => r.Add(_aluno)).Returns(_aluno);

            //acao
            var alunoAdicionado = _servico.Add(_aluno);

            //verificar
            alunoAdicionado.Id.Should().Be(_aluno.Id);
            _mockRepositorio.Verify(r => r.Add(_aluno));
        }

        [Test]
        public void Aluno_Aplicacao_Get_Deve_Obter_Aluno()
        {
            //cenario
            _aluno.Id = 1;
            _mockRepositorio.Setup(r => r.Get(_aluno.Id)).Returns(_aluno);

            //acao
            var alunoObtido = _servico.Get(_aluno.Id);

            //verificar
            alunoObtido.Id.Should().Be(_aluno.Id);
            _mockRepositorio.Verify(r => r.Get(_aluno.Id));
        }

        [Test]
        public void Aluno_Aplicacao_GetAll_Deve_Obter_Todos_Alunos()
        {
            //cenario
            _mockRepositorio.Setup(r => r.GetAll()).Returns(new List<Aluno> { _aluno });

            //acao
            var alunos = _servico.GetAll();

            //verificar
            alunos.First().Should().Equals(_aluno);
            _mockRepositorio.Verify(r => r.GetAll());
        }

        [Test]
        public void Aluno_Aplicacao_Delete_Deve_Excluir_Aluno()
        {
            //cenario
            _aluno.Id = 1;
            _mockRepositorio.Setup(r => r.Delete(_aluno));

            //acao
            Action action = () => _servico.Delete(_aluno);

            //verificar
            action.Should().NotThrow<Exception>();
            _mockRepositorio.Verify(r => r.Delete(_aluno));
        }

        [Test]
        public void Aluno_Aplicacao_Update_Deve_Atualizar_Aluno()
        {
            //cenario
            _aluno.Id = 1;
            _aluno.Nome = "atualizado";
            _mockRepositorio.Setup(r => r.Update(_aluno)).Returns(_aluno);

            //acao
            var alunoAtualizado = _servico.Update(_aluno);

            //verificar
            alunoAtualizado.Nome.Should().Be(_aluno.Nome);
            _mockRepositorio.Verify(r => r.Update(_aluno));
        }
    }
}
