using FluentAssertions;
using MediaProva.Common.Tests.Base;
using MediaProva.Common.Tests.Features.Avaliacoes;
using MediaProva.Domain.Features.Avaliacoes;
using MediaProva.Infra.Data.Base;
using MediaProva.Infra.Data.Features.Avaliacoes;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace MediaProva.Infra.Data.Tests.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoRepositoryTestes
    {
        MediaProvaContext _contexto;
        AvaliacaoRepository _repositorio;
        Avaliacao _avaliacao;

        [SetUp]
        public void SetUp()
        {
            _contexto = new MediaProvaContext();
            _repositorio = new AvaliacaoRepository(_contexto);
            _avaliacao = AvaliacaoObjectMother.CriarAvaliacaoValida();
            Database.SetInitializer(new BaseSqlTest());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Teste_Avaliacao_InfraData_Add_Deve_Inserir_Avaliacao()
        {
            //Cenario

            //Acao
            _avaliacao = _repositorio.Add(_avaliacao);

            //Verificacao
            _avaliacao.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Avaliacao_InfraData_Get_Deve_Obter_Avaliacao_PorId()
        {
            //Cenario
            _avaliacao = _repositorio.Add(_avaliacao);

            //Acao
            var avaliacaoObtido = _repositorio.Get(_avaliacao.Id);

            //Verificacao
            avaliacaoObtido.Id.Should().Be(_avaliacao.Id);
        }

        [Test]
        public void Teste_Avaliacao_InfraData_GetAll_Deve_Obter_Todos_Avaliacaos()
        {
            //Cenario
            _avaliacao.Id = 1;

            //Acao
            var avaliacaos = _repositorio.GetAll();

            //Verificacao
            avaliacaos.Count().Should().BeGreaterThan(0);
            avaliacaos.First().Id.Should().Be(_avaliacao.Id);
        }

        [Test]
        public void Teste_Avaliacao_InfraData_Delete_Deve_Deletar_Avaliacao()
        {
            //Cenario
            _avaliacao = _repositorio.Add(_avaliacao);

            //Acao
            _repositorio.Delete(_avaliacao);
            var avaliacaoExcluido = _repositorio.Get(_avaliacao.Id);

            //Verificacao
            avaliacaoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Avaliacao_InfraData_Update_Deve_Atualizar_Avaliacao()
        {
            //Cenario
            _avaliacao = _repositorio.Add(_avaliacao);
            _avaliacao.Assunto = "atualizado";

            //Acao
            var avaliacaoAtualizado = _repositorio.Update(_avaliacao);

            //Verificacao
            avaliacaoAtualizado.Assunto.Should().Be(_avaliacao.Assunto);
        }
    }
}
