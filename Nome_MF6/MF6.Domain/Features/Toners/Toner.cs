using MF6.Domain.Base;
using MF6.Domain.Exceptions;

namespace MF6.Domain.Features.Toners
{
    public class Toner
    {
        public double Nivel { get; set; }

        public Toner()
        {
            Nivel = 100;
        }

        public void AumentarNivel(double quantidade)
        {
            if (this.Nivel == 100)
                throw new NotAllowedException();

            this.Nivel += quantidade;
        }

        public void DiminuirNivel(double quantidade)
        {
            if (this.Nivel < 1)
                throw new NotAllowedException();

            this.Nivel -= quantidade;
        }
    }
}
