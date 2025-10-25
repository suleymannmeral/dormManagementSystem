namespace YurtYonetimSistemi.Application.Features;

public record RoomDto(
    int Id,
    int Capacity,
    bool IsAvailable,
    List<StudentDto> Students
    );



