using AndersonLiz.Agenda.Doamain.Base;
using System;
using System.Text.RegularExpressions;

namespace AndersonLiz.Agenda.Doamain
{
    public class Contato : Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Departamento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4}", Nome, Email, Departamento, Endereco, Telefone);
        }

        public override void Valida()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new InvalidOperationException("O nome do contato é obrigatório!");

            if (Nome.Length > 30)
                throw new InvalidOperationException("O nome do contato deve ser menor que 30 caracteres!");

            if (!Regex.IsMatch(Nome.ToLower(), @"^[a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new InvalidOperationException("O nome do contato não pode conter caractres especiais ou números!");

            if (string.IsNullOrEmpty(Email))
                throw new InvalidOperationException("O email do contato é obrigatório!");

            if (Email.Length > 30)
                throw new InvalidOperationException("O email do contato deve ser menor que 30 caracteres!");

            if (string.IsNullOrEmpty(Departamento))
                throw new InvalidOperationException("O departamento do contato é obrigatório!");

            if (Departamento.Length > 30)
                throw new InvalidOperationException("O departamento do contato deve ser menor que 30 caracteres!");

            if (!Regex.IsMatch(Departamento.ToLower(), @"^[a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new InvalidOperationException("O departamento do contato não pode conter caractres especiais ou números!");

            if (string.IsNullOrEmpty(Endereco))
                throw new InvalidOperationException("O endereco do contato é obrigatório!");

            if (Endereco.Length > 30)
                throw new InvalidOperationException("O endereco do contato deve ser menor que 30 caracteres!");

            if (!Regex.IsMatch(Endereco.ToLower(), @"^[1-9a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new InvalidOperationException("O endereco do contato não pode conter caractres especiais!");

            if (string.IsNullOrEmpty(Telefone))
                throw new InvalidOperationException("O telefone do contato é obrigatório!");

            if (Telefone.Length > 14)
                throw new InvalidOperationException("O telefone do contato deve ser menor que 15 caracteres!");

            if (!Regex.IsMatch(Telefone.ToLower(), @"^[1-9]+$"))
                throw new InvalidOperationException("O telefone do contato aceita somente números!");
        }
    }
}
