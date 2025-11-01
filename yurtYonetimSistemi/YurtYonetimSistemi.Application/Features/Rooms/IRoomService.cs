using YurtYonetimSistemi.Application.Features.Rooms.Create;
using YurtYonetimSistemi.Application.Features.Rooms.Update;

namespace YurtYonetimSistemi.Application.Features.Rooms;

public  interface IRoomService
{
    Task<ServiceResult<CreateRoomResponse>> CreateAsync(CreateRoomRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateRoomRequest request);
    Task<ServiceResult<RoomDto>> GetByIdAsync(int id);
}
