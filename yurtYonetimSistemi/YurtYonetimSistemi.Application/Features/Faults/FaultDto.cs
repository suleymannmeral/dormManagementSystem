namespace YurtYonetimSistemi.Application.Features.Faults;

public record FaultDto(
    int Id,
    string Title,
    string Description,
    int StudentId,
    int RoomId,
    string FullName
);
