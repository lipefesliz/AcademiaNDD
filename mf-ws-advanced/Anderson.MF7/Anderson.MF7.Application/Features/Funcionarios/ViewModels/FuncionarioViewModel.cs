namespace Anderson.MF7.Application.Features.Funcionarios.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public string Cargo { get; set; }
    }
}
