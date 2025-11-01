using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Rooms.Create;
using YurtYonetimSistemi.Application.Features.Rooms.Update;
using YurtYonetimSistemi.Application.Features.Students;
using YurtYonetimSistemi.Application.Features.Users;
using YurtYonetimSistemi.Domain.Entities;

namespace YurtYonetimSistemi.Application.Features.Rooms;

public class RoomService(IRoomRepository roomRepository,
    IUnitOfWork unitOfWork,
    IStudentRepository studentRepository,
    IUserService userService):IRoomService
{

    public async Task<ServiceResult<RoomDto>> GetByIdAsync(int id)
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
    public async Task<ServiceResult<CreateRoomResponse>> CreateAsync(CreateRoomRequest request)
    {
        var anyRoom = await roomRepository.AnyAsync(r=>r.RoomNumber == request.RoomNumber);

        if(anyRoom)
        {
            return ServiceResult<CreateRoomResponse>.Fail("Room number already exist", HttpStatusCode.BadRequest);

        }

        var room = new Room()
        {
            RoomNumber = request.RoomNumber,
            Capacity = request.Capacity,
            IsAvailable = true

        };

        await roomRepository.AddAsync(room);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateRoomResponse>.Success(new CreateRoomResponse(room.Id));
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateRoomRequest request)
    {
        var room = await roomRepository.GetByIdAsync(id);

        if (room is null)
        {
            return ServiceResult.Fail("Room not found", HttpStatusCode.NotFound);
        }

        room.RoomNumber = request.RoomNumber;
        room.Capacity = request.Capacity;

        roomRepository.Update(room);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success();

    }




}
