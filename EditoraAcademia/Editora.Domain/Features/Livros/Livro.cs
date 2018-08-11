using EditoraAcademia.Domain.Base;
using System;
using System.Text.RegularExpressions;

namespace EditoraAcademia.Domain.Features.Livros
{
    public class Livro : Entidade
    {
        public string Titulo { get; set; }
        public string Ano { get; set; }
        public string Autor { get; set; }
        public string Volume { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", Titulo, Ano, Autor, Volume);
        }

        public override void Valida()
        {
            if (string.IsNullOrEmpty(Titulo))
                throw new InvalidOperationException("O titulo do livro é obrigatório!");

            if (Titulo.Length > 30)
                throw new InvalidOperationException("O nome do contato deve ser menor que 30 caracteres!");

            if (string.IsNullOrEmpty(Ano))
                throw new InvalidOperationException("O ano do livro é obrigatório!");

            if (Ano.Length > 4)
                throw new InvalidOperationException("O ano de lancamento deve ser menor que 5 caracteres!");

            if (!Regex.IsMatch(Ano.ToLower(), @"^\d+$"))
                throw new InvalidOperationException("O ano do livro deve conter somente números!");

            if (string.IsNullOrEmpty(Autor))
                throw new InvalidOperationException("O autor do livro é obrigatório!");

            if (Autor.Length > 30)
                throw new InvalidOperationException("O nome do autor deve ser menor que 30 caracteres!");

            if (!Regex.IsMatch(Autor.ToLower(), @"^[1-9a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new InvalidOperationException("O nome do autor não pode conter caractres especiais!");

            if (string.IsNullOrEmpty(Volume))
                throw new InvalidOperationException("O volume do livro é obrigatório!");

            if (Volume.Length > 10)
                throw new InvalidOperationException("O volume do livro deve ser menor que 10 caracteres!");

            if (!Regex.IsMatch(Volume.ToLower(), @"^[1-9a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new InvalidOperationException("O endereco do contato não pode conter caractres especiais!");
        }
    }
}
