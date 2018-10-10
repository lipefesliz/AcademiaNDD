using Anderson.ORM.Common.Tests.Base;
using Anderson.ORM.Common.Tests.Features.Funcionarios;
using Anderson.ORM.Domain.Features.Funcionarios;
using Anderson.ORM.Infra.Data.Base;
using Anderson.ORM.Infra.Data.Features.Cargos;
using Anderson.ORM.Infra.Data.Features.Departamentos;
using Anderson.ORM.Infra.Data.Features.Enderecos;
using Anderson.ORM.Infra.Data.Features.Funcionarios;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Anderson.ORM.Infra.Data.Tests.Features.Funcionarios
{
    [TestFixture]
    public class FuncionarioRepositoryTests
    {
        AndersonORMContext _contexto;
        FuncionarioRepository _repositorio;
        CargoRepository _cargoRepositorio;
        DepartamentoRepository _departamentoRepositorio;
        EnderecoRepository _enderecoRepositorio;
        Funcionario _funcionario;

        [SetUp]
        public void SetUp()
        {
            _contexto = new AndersonORMContext();
            _repositorio = new FuncionarioRepository(_contexto);
            _cargoRepositorio = new CargoRepository(_contexto);
            _departamentoRepositorio = new DepartamentoRepository(_contexto);
            _enderecoRepositorio = new EnderecoRepository(_contexto);
            _funcionario = FuncionarioObjectMother.CriarFuncionarioValido();
            Database.SetInitializer(new BaseSqlTest());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Teste_Funcionario_InfraData_Add_Deve_Inserir_Funcionario()
        {
            //Cenario
            var id = 1;
            var cargo = _cargoRepositorio.Get(id);
            var departamento = _departamentoRepositorio.Get(id);
            var endereco = _enderecoRepositorio.Get(id);
            _funcionario.Cargo = cargo;
            _funcionario.Departamento = departamento;
            _funcionario.Endereco = endereco;

            //Acao
            _funcionario = _repositorio.Add(_funcionario);

            //Verificacao
            _funcionario.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Funcionario_InfraData_Get_Deve_Obter_Funcionario_PorId()
        {
            //Cenario
            var id = 1;
            var cargo = _cargoRepositorio.Get(id);
            var departamento = _departamentoRepositorio.Get(id);
            var endereco = _enderecoRepositorio.Get(id);
            _funcionario.Cargo = cargo;
            _funcionario.Departamento = departamento;
            _funcionario.Endereco = endereco;
            _funcionario = _repositorio.Add(_funcionario);

            //Acao
            var funcionarioObtido = _repositorio.Get(_funcionario.Id);

            //Verificacao
            funcionarioObtido.Id.Should().Be(_funcionario.Id);
        }

        [Test]
        public void Teste_Funcionario_InfraData_GetAll_Deve_Obter_Todos_Funcionarios()
        {
            //Cenario
            _funcionario.Id = 1;

            //Acao
            var funcionarios = _repositorio.GetAll();

            //Verificacao
            funcionarios.Count().Should().BeGreaterThan(0);
            funcionarios.First().Id.Should().Be(_funcionario.Id);
        }

        [Test]
        public void Teste_Funcionario_InfraData_Delete_Deve_Deletar_Funcionario()
        {
            //Cenario
            var id = 1;
            var cargo = _cargoRepositorio.Get(id);
            var departamento = _departamentoRepositorio.Get(id);
            var endereco = _enderecoRepositorio.Get(id);
            _funcionario.Cargo = cargo;
            _funcionario.Departamento = departamento;
            _funcionario.Endereco = endereco;
            _funcionario = _repositorio.Add(_funcionario);

            //Acao
            _repositorio.Delete(_funcionario);
            var departamentoExcluido = _repositorio.Get(_funcionario.Id);

            //Verificacao
            departamentoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Funcionario_InfraData_Update_Deve_Atualizar_Funcionario()
        {
            //Cenario
            var id = 1;
            var cargo = _cargoRepositorio.Get(id);
            var departamento = _departamentoRepositorio.Get(id);
            var endereco = _enderecoRepositorio.Get(id);
            _funcionario.Cargo = cargo;
            _funcionario.Departamento = departamento;
            _funcionario.Endereco = endereco;
            _funcionario = _repositorio.Add(_funcionario);
            _funcionario.Nome = "atualizado";

            //Acao
            var funcionarioAtualizado = _repositorio.Update(_funcionario);

            //Verificacao
            funcionarioAtualizado.Nome.Should().Be(_funcionario.Nome);
        }

        [Test]
        public void Teste_Funcionario_InfraData_ObterPorCargo_Deve_Obter_Funcionarios()
        {
            //Cenario
            var id = 1;
            var cargo = _cargoRepositorio.Get(id);
            var departamento = _departamentoRepositorio.Get(id);
            var endereco = _enderecoRepositorio.Get(id);
            _funcionario.Cargo = cargo;
            _funcionario.Departamento = departamento;
            _funcionario.Endereco = endereco;
            _funcionario = _repositorio.Add(_funcionario);

            //Acao
            var funcionarios = _repositorio.ObterPorCargo(cargo.Descricao);

            //Verificacao
            funcionarios.Count().Should().BeGreaterThan(0);
            funcionarios.First().Cargo.Should().Be(_funcionario.Cargo);
        }
    }
}
