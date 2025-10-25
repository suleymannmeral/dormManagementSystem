namespace YurtYonetimSistemi.Application.Features.Students;

public record StudentDto(
    int Id,
    int UserId,
    string FullName,
    int RoomId,
    string Department,
    string University
    );


