using AndersonLiz.Agenda.Doamain.Base;

namespace AndersonLiz.Agenda.Doamain.Features.Contatos
{
    public interface IContatoRepository : IRepository<Contato>
    {
        bool Existe(string nome);

        bool Existe(int id, string nome);

        bool RegistroComDependencia(int id);
    }
}
