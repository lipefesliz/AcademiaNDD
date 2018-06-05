using SalaReuniao.Domain.Base;
using SalaReuniao.Features.Rooms.Exceptions;

namespace SalaReuniao.Features.Rooms
{
    public class Room : Entity
    {
        public string Name { get; set; }
        public int Chairs { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new EmptyNameException();

            if (Chairs < 1)
                throw new ChairsNumberException();
        }
    }
}
