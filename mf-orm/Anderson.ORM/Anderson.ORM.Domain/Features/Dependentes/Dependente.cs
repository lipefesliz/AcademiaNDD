using Anderson.ORM.Domain.Base;
using Anderson.ORM.Domain.Features.Funcionarios;

namespace Anderson.ORM.Domain.Features.Dependentes
{
    public class Dependente : Entity
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        public Dependente()
        {
            Funcionario = new Funcionario();
        }

        public override void Validate()
        {
        }
    }
}
