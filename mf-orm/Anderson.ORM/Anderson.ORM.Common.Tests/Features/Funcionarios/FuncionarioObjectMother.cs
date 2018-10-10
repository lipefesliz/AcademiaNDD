using Anderson.ORM.Domain.Features.Cargos;
using Anderson.ORM.Domain.Features.Departamentos;
using Anderson.ORM.Domain.Features.Enderecos;
using Anderson.ORM.Domain.Features.Funcionarios;
using Anderson.ORM.Domain.Features.Projetos;

namespace Anderson.ORM.Common.Tests.Features.Funcionarios
{
    public static class FuncionarioObjectMother
    {
        public static Funcionario CriarFuncionarioValido()
        {
            var funcionario = new Funcionario();

            funcionario.Nome = "nome";
            funcionario.Cargo = new Cargo();
            funcionario.Departamento = new Departamento();
            funcionario.Endereco = new Endereco();

            return funcionario;
        }

        public static Funcionario CriarFuncionarioValido(Cargo cargo, Departamento departamento, Endereco endereco)
        {
            var funcionario = new Funcionario();

            funcionario.Nome = "nome";
            funcionario.Cargo = cargo;
            funcionario.Departamento = departamento;
            funcionario.Endereco = endereco;

            return funcionario;
        }
    }
}
