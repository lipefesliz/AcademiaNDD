using FluentAssertions;
using MediaProva.Application.Resultados;
using MediaProva.Common.Tests.Base;
using MediaProva.Common.Tests.Features.Resultados;
using MediaProva.Domain.Features.Resultados;
using MediaProva.Infra.Data.Base;
using NUnit.Framework;
using ProjetoModelo.Infra.Data.Features.Resultados;
using System.Data.Entity;
using System.Linq;

namespace MediaProva.Integration.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoIntegrationTests
    {
        MediaProvaContext _context;
        ResultadoRepository _repositorio;
        ResultadoService _servico;
        Resultado _resultado;

        [SetUp]
        public void SetUp()
        {
            _context = new MediaProvaContext();
            _repositorio = new ResultadoRepository(_context);
            _servico = new ResultadoService(_repositorio);
            _resultado = ResultadoObjectMother.CriarResultadoValido();
            Database.SetInitializer(new BaseSqlTest());
            _context.Database.Initialize(true);
        }

        [Test]
        public void Teste_Resultado_Integracao_Add_Deve_Inserir_Resultado()
        {
            //Cenario

            //Acao
            _resultado = _servico.Add(_resultado);

            //Verificacao
            _resultado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Resultado_Integracao_Get_Deve_Obter_Resultado_PorId()
        {
            //Cenario
            _resultado = _servico.Add(_resultado);

            //Acao
            var resultadoObtido = _servico.Get(_resultado.Id);

            //Verificacao
            resultadoObtido.Id.Should().Be(_resultado.Id);
        }

        [Test]
        public void Teste_Resultado_Integracao_GetAll_Deve_Obter_Todos_Resultados()
        {
            //Cenario
            _resultado.Id = 1;

            //Acao
            var resultados = _servico.GetAll();

            //Verificacao
            resultados.Count().Should().BeGreaterThan(0);
            resultados.First().Id.Should().Be(_resultado.Id);
        }

        [Test]
        public void Teste_Resultado_Integracao_Delete_Deve_Deletar_Resultado()
        {
            //Cenario
            _resultado = _servico.Add(_resultado);

            //Acao
            _servico.Delete(_resultado);
            var resultadoExcluido = _servico.Get(_resultado.Id);

            //Verificacao
            resultadoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Resultado_Integracao_Update_Deve_Atualizar_Resultado()
        {
            //Cenario
            _resultado = _servico.Add(_resultado);
            _resultado.Nota = 5;

            //Acao
            var resultadoAtualizado = _servico.Update(_resultado);

            //Verificacao
            resultadoAtualizado.Nota.Should().Be(_resultado.Nota);
        }
    }
}
