using MF6.Domain.Base;
using MF6.Domain.Exceptions;
using MF6.Domain.Features.Toners;

namespace MF6.Domain.Features.Impressoras
{
    public class Impressora : Entity
    {
        public string Marca { get; set; }
        public string Rede { get; set; }
        public bool EmUso { get; set; }
        public Toner TonerColorido { get; set; }
        public Toner TonerPreto { get; set; }

        public Impressora()
        {
            TonerColorido = new Toner();
            TonerPreto = new Toner();
        }

        public override bool Validate()
        {
            if (!this.EmUso)
                throw new NotAllowedException();

            return true;
        }
    }
}
