using Anderson.ORM.Common.Tests.Base;
using Anderson.ORM.Common.Tests.Features.Enderecos;
using Anderson.ORM.Domain.Features.Enderecos;
using Anderson.ORM.Infra.Data.Base;
using Anderson.ORM.Infra.Data.Features.Enderecos;
using FluentAssertions;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace Anderson.ORM.Infra.Data.Tests.Features.Enderecos
{
    [TestFixture]
    public class EnderecoRepositoryTests
    {
        AndersonORMContext _contexto;
        EnderecoRepository _repositorio;
        Endereco _endereco;

        [SetUp]
        public void SetUp()
        {
            _contexto = new AndersonORMContext();
            _repositorio = new EnderecoRepository(_contexto);
            _endereco = EnderecoObjectMother.CriarEnderecoValido();
            Database.SetInitializer(new BaseSqlTest());
            _contexto.Database.Initialize(true);
        }

        [Test]
        public void Teste_Endereco_InfraData_Add_Deve_Inserir_Endereco()
        {
            //Cenario

            //Acao
            _endereco = _repositorio.Add(_endereco);

            //Verificacao
            _endereco.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Endereco_InfraData_Get_Deve_Obter_Endereco_PorId()
        {
            //Cenario
            _endereco = _repositorio.Add(_endereco);

            //Acao
            var enderecoObtido = _repositorio.Get(_endereco.Id);

            //Verificacao
            enderecoObtido.Id.Should().Be(_endereco.Id);
        }

        [Test]
        public void Teste_Endereco_InfraData_GetAll_Deve_Obter_Todos_Enderecos()
        {
            //Cenario
            _endereco.Id = 1;

            //Acao
            var enderecos = _repositorio.GetAll();

            //Verificacao
            enderecos.Count().Should().BeGreaterThan(0);
            enderecos.First().Id.Should().Be(_endereco.Id);
        }

        [Test]
        public void Teste_Endereco_InfraData_Delete_Deve_Deletar_Endereco()
        {
            //Cenario
            _endereco = _repositorio.Add(_endereco);

            //Acao
            _repositorio.Delete(_endereco);
            var departamentoExcluido = _repositorio.Get(_endereco.Id);

            //Verificacao
            departamentoExcluido.Should().BeNull();
        }

        [Test]
        public void Teste_Endereco_InfraData_Update_Deve_Atualizar_Endereco()
        {
            //Cenario
            _endereco = _repositorio.Add(_endereco);
            _endereco.Rua = "atualizado";

            //Acao
            var enderecoAtualizado = _repositorio.Update(_endereco);

            //Verificacao
            enderecoAtualizado.Rua.Should().Be(_endereco.Rua);
        }
    }
}
