using YurtYonetimSistemi.Application.Features.Rooms.Create;

namespace YurtYonetimSistemi.Application.Features.Rooms;

public  interface IRoomService
{
    Task<ServiceResult<CreateRoomResponse>> CreateAsync(CreateRoomRequest request);
}
