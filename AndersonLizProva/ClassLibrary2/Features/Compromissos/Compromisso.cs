using AndersonLiz.Agenda.Doamain;
using AndersonLiz.Agenda.Doamain.Base;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AndersonLiz.Agenda.Doamain.Features.Compromissos
{
    public class Compromisso : Entidade
    {
        public string Assunto { get; set; }
        public IList<Contato> Contatos { get; set; }
        public string Local { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", Inicio.Date.ToShortDateString(), Termino.Date.ToShortDateString(), Assunto, Local);
            //return string.Format("{0} - {1} - {2} - {3} - {4}", Contatos.ToString(), Assunto, Local, Inicio, Termino);
        }

        public override void Valida()
        {
            if (string.IsNullOrEmpty(Assunto))
                throw new InvalidOperationException("O assunto é obrigatório!");

            if (Assunto.Length > 30)
                throw new InvalidOperationException("O assunto deve ser menor que 30 caracteres!");

            if (!Regex.IsMatch(Assunto.ToLower(), @"^[a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new InvalidOperationException("O assunto não pode conter caractres especiais ou números!");

            if (string.IsNullOrEmpty(Local))
                throw new InvalidOperationException("O local é obrigatório!");

            if (Local.Length > 30)
                throw new InvalidOperationException("O local deve ser menor que 30 caracteres!");

            if (!Regex.IsMatch(Local.ToLower(), @"^[a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new InvalidOperationException("O local não pode conter caractres especiais ou números!");

            if (Termino < Inicio)
                throw new InvalidOperationException("A data de termino não pode ser anterior a data de início!");
        }
    }
}
