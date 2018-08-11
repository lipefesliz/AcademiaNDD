using Anderson.ORM.Domain.Base;

namespace Anderson.ORM.Domain.Features.Enderecos
{
    public class Endereco : Entity
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
