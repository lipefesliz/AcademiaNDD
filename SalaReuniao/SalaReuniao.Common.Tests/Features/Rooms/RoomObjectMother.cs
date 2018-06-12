using SalaReuniao.Features.Rooms;

namespace SalaReuniao.Common.Tests.Features.Rooms
{
    public static partial class RoomObjectMother
    {
        public static Room CreateValidRoom()
        {
            return new Room
            {
                Id = 1,
                Name = "sala de reuniao",
                Chairs = 10
            };
        }
    }
}
