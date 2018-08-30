using MF6.Domain.Base;
using MF6.Domain.Features.Toners;

namespace MF6.Domain.Features.Impressora
{
    public class Impressora : Entity
    {
        public string Marca { get; set; }
        public string Rede { get; set; }
        public bool EmUso { get; set; }
        public virtual Toner TonerColorido { get; set; }
        public virtual Toner TonerPreto { get; set; }

        public Impressora()
        {
            TonerColorido = new Toner();
            TonerPreto = new Toner();
        }
    }
}
