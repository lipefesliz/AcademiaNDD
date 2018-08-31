namespace Anderson.MF7.Domain.Features.Funcionarios
{
    public class Funcionario : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public string Cargo { get; set; }
    }
}
