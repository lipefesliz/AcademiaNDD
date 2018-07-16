using FluentAssertions;
using MediaProva.Common.Tests.Base;
using MediaProva.Common.Tests.Features.Resultados;
using MediaProva.Domain.Features.Resultados;
using MediaProva.Infra.Data.Base;
using NUnit.Framework;
using ProjetoModelo.Infra.Data.Features.Resultados;
using System.Data.Entity;
using System.Linq;

namespace MediaProva.Infra.Data.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoRepositoryTestes
    {
        MediaProvaContext _contexto;
        ResultadoRepository _repositorio;
        Resultado _resultado;

        [SetUp]
        public void SetUp()
        {
            _contexto = new MediaProvaContext();
            _repositorio = new ResultadoRepository(_contexto);
            _resultado = ResultadoObjectMother.CriarResultadoValido();
            Database.SetInitializer(new BaseSqlTest());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Teste_Resultado_InfraData_Add_Deve_Inserir_Resultado()
        {
            //Cenario

            //Acao
            _resultado = _repositorio.Add(_resultado);

            //Verificacao
            _resultado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Resultado_InfraData_Get_Deve_Obter_Resultado_PorId()
        {
            //Cenario
            _resultado = _repositorio.Add(_resultado);

            //Acao
            var resultadoObtido = _repositorio.Get(_resultado.Id);

            //Verificacao
            resultadoObtido.Id.Should().Be(_resultado.Id);
        }

        [Test]
        public void Teste_Resultado_InfraData_GetAll_Deve_Obter_Todos_Resultados()
        {
            //Cenario
            _resultado.Id = 1;

            //Acao
            var resultados = _repositorio.GetAll();

            //Verificacao
            resultados.Count().Should().BeGreaterThan(0);
            resultados.First().Id.Should().Be(_resultado.Id);
        }

        [Test]
        public void Teste_Resultado_InfraData_Delete_Deve_Deletar_Resultado()
        {
            //Cenario
            var id = 1;
            _resultado = _repositorio.Get(id);

            //Acao
            _repositorio.Delete(_resultado);
            var resultadoExcluido = _repositorio.Get(_resultado.Id);

            //Verificacao
            resultadoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Resultado_InfraData_Update_Deve_Atualizar_Resultado()
        {
            //Cenario
            _resultado = _repositorio.Add(_resultado);
            _resultado.Nota = 10;

            //Acao
            var resultadoAtualizado = _repositorio.Update(_resultado);

            //Verificacao
            resultadoAtualizado.Nota.Should().Be(_resultado.Nota);
        }
    }
}
