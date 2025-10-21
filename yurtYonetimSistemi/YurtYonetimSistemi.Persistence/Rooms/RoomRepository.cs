using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence.Rooms;

public class RoomRepository(AppDbContext context): GenericRepository<Room, int>(context), IRoomRepository
{
}
