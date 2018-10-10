using Anderson.ORM.Domain.Base;
using Anderson.ORM.Domain.Features.Funcionarios;
using System;
using System.Collections.Generic;

namespace Anderson.ORM.Domain.Features.Projetos
{
    public class Projeto : Entity
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }

        public Projeto()
        {
            Funcionarios = new List<Funcionario>();
        }

        public void AdicionarFuncionario(params Funcionario[] funcionarios)
        {
            foreach (var funcionario in funcionarios)
            {
                if (funcionario != null)
                    Funcionarios.Add(funcionario);
            }
        }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
