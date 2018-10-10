using Anderson.ORM.Common.Tests.Base;
using Anderson.ORM.Common.Tests.Features.Cargos;
using Anderson.ORM.Domain.Features.Cargos;
using Anderson.ORM.Infra.Data.Base;
using Anderson.ORM.Infra.Data.Features.Cargos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Anderson.ORM.Infra.Data.Tests.Features.Cargos
{
    [TestFixture]
    public class CargoRepositoryTests
    {
        AndersonORMContext _contexto;
        CargoRepository _repositorio;
        Cargo _cargo;

        [SetUp]
        public void SetUp()
        {
            _contexto = new AndersonORMContext();
            _repositorio = new CargoRepository(_contexto);
            _cargo = CargoObjectMother.CriarCargoValido();
            Database.SetInitializer(new BaseSqlTest());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Teste_Cargo_InfraData_Add_Deve_Inserir_Cargo()
        {
            //Cenario

            //Acao
            _cargo = _repositorio.Add(_cargo);

            //Verificacao
            _cargo.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Cargo_InfraData_Get_Deve_Obter_Cargo_PorId()
        {
            //Cenario
            _cargo = _repositorio.Add(_cargo);

            //Acao
            var cargoObtido = _repositorio.Get(_cargo.Id);

            //Verificacao
            cargoObtido.Id.Should().Be(_cargo.Id);
        }

        [Test]
        public void Teste_Cargo_InfraData_GetAll_Deve_Obter_Todos_Cargos()
        {
            //Cenario
            _cargo.Id = 1;

            //Acao
            var cargos = _repositorio.GetAll();

            //Verificacao
            cargos.Count().Should().BeGreaterThan(0);
            cargos.First().Id.Should().Be(_cargo.Id);
        }

        [Test]
        public void Teste_Cargo_InfraData_Delete_Deve_Deletar_Cargo()
        {
            //Cenario
            _cargo = _repositorio.Add(_cargo);

            //Acao
            _repositorio.Delete(_cargo);
            var cargoExcluido = _repositorio.Get(_cargo.Id);

            //Verificacao
            cargoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Cargo_InfraData_Update_Deve_Atualizar_Cargo()
        {
            //Cenario
            _cargo = _repositorio.Add(_cargo);
            _cargo.Descricao = "atualizado";

            //Acao
            var cargoAtualizado = _repositorio.Update(_cargo);

            //Verificacao
            cargoAtualizado.Descricao.Should().Be(_cargo.Descricao);
        }
    }
}
