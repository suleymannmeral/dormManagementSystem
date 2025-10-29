using System.Net;
using YurtYonetimSistemi.Application.Contracts.Identity;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Students;

namespace YurtYonetimSistemi.Application.Features.Rooms;

public class RoomService(IRoomRepository roomRepository,
    IUnitOfWork unitOfWork,
    IStudentRepository studentRepository,
    IUserService userService):IRoomService
{

    public async Task<ServiceResult<RoomDto>> GetRoomByIdAsync(int id)
    {
        var room = await roomRepository.GetByIdAsync(id);
        // Check if room exists
        if (room is null)
        {
            return ServiceResult<RoomDto>.Fail("Room not found",HttpStatusCode.NotFound);
        }

        var students = await studentRepository.GetStudentsByRoomIdAsync(room.Id);

        var studentDtos = new List<StudentDto>();
        foreach (var student in students)
        {
            var fullName = await userService.GetFullNameByUserIdAsync(student.UserId);

            studentDtos.Add(new StudentDto(
                student.Id,
                student.UserId,
                fullName!,
                student.RoomId,
                student.Department,
                student.University
            ));
        }
        var roomDto = new RoomDto(
            room.Id,
            room.Capacity,
            room.IsAvailable,
            studentDtos 
        );
        return ServiceResult<RoomDto>.Success(roomDto);
    }
}
