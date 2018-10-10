using Anderson.ORM.Domain.Features.Funcionarios;
using Anderson.ORM.Domain.Features.Projetos;
using System;
using System.Collections.Generic;

namespace Anderson.ORM.Common.Tests.Features.Projetos
{
    public static class ProjetoObjectMother
    {
        public static Projeto CriarProjetoValido()
        {
            var projeto = new Projeto();

            projeto.Nome = "projeto";
            projeto.DataInicio = DateTime.Now;
            projeto.Funcionarios = new List<Funcionario>();

            return projeto;
        }

        public static Projeto CriarProjetoValido(Funcionario funcionario)
        {
            var projeto = new Projeto();

            projeto.Nome = "projeto";
            projeto.DataInicio = DateTime.Now;
            projeto.AdicionarFuncionario(funcionario);

            return projeto;
        }
    }
}
