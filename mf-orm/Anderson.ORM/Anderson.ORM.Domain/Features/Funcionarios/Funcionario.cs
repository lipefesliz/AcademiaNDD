using Anderson.ORM.Domain.Base;
using Anderson.ORM.Domain.Features.Cargos;
using Anderson.ORM.Domain.Features.Departamentos;
using Anderson.ORM.Domain.Features.Enderecos;
using Anderson.ORM.Domain.Features.Projetos;
using System.Collections.Generic;

namespace Anderson.ORM.Domain.Features.Funcionarios
{
    public class Funcionario : Entity
    {
        public string Nome { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
        public virtual string Cpf { get; set; }

        public Funcionario()
        {
            Projetos = new List<Projeto>();
        }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
