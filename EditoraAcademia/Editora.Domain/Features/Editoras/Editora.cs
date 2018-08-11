using EditoraAcademia.Domain.Base;
using EditoraAcademia.Domain.Features.Livros;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EditoraAcademia.Domain.Features.Editoras
{
    public class Editora : Entidade
    {
        public string Nome { get; set; }
        public IList<Livro> Livros { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", Nome, Endereco, Telefone);
        }

        public override void Valida()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new InvalidOperationException("O nome da editora é obrigatório!");

            if (Nome.Length > 30)
                throw new InvalidOperationException("O nome da efitora deve ser menor que 30 caracteres!");

            if (!Regex.IsMatch(Nome.ToLower(), @"^[1-9a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new InvalidOperationException("O nome não pode conter caractres especiais!");

            if (string.IsNullOrEmpty(Endereco))
                throw new InvalidOperationException("O endereco é obrigatório!");

            if (Endereco.Length > 30)
                throw new InvalidOperationException("O endereco deve ser menor que 30 caracteres!");

            if (!Regex.IsMatch(Endereco.ToLower(), @"^[1-9a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new InvalidOperationException("O endereco não pode conter caractres especiais!");

            if (string.IsNullOrEmpty(Telefone))
                throw new InvalidOperationException("O telefone é obrigatório!");

            if (Telefone.Length > 30)
                throw new InvalidOperationException("O telefone deve ser menor que 30 caracteres!");

            if (!Regex.IsMatch(Telefone.ToLower(), @"^\d+$"))
                throw new InvalidOperationException("O telefone deve conter apenas numeros!");

            if (Livros.Count <= 0)
                throw new InvalidOperationException("Adicione pelo menos um livro!");
        }
    }
}
