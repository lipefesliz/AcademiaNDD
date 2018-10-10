using Anderson.ORM.Common.Tests.Features.Funcionarios;
using Anderson.ORM.Domain.Features.Enderecos;
using Anderson.ORM.Domain.Features.Funcionarios;

namespace Anderson.ORM.Common.Tests.Features.Enderecos
{
    public static class EnderecoObjectMother
    {
        public static Endereco CriarEnderecoValido()
        {
            var endereco = new Endereco();

            endereco.Bairro = "bairro";
            endereco.Cep = "cep";
            endereco.Cidade = "cidade";
            endereco.Complemento = "complemento";
            endereco.Estado = "estado";
            endereco.Rua = "rua";
            endereco.Numero = 123;

            return endereco;
        }
    }
}
