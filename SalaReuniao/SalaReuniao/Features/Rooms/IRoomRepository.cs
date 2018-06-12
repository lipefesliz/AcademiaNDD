using SalaReuniao.Domain.Base;

namespace SalaReuniao.Features.Rooms
{
    public interface IRoomRepository : IRepository<Room>
    {
        bool Exist(string name);

        Room GetByName(string name);

        bool IsTiedTo(long id);
    }
}
