using AndersonLiz.Agenda.Doamain.Base;
using System;
using System.Collections.Generic;

namespace AndersonLiz.Agenda.Doamain.Features.Compromissos
{
    public interface ICompromissoRepository : IRepository<Compromisso>
    {
        bool Existe(DateTime inicio);

        bool Existe(int id, DateTime inicio);

        IList<Contato> GetContatosFromCompromissos(int id);
    }
}
