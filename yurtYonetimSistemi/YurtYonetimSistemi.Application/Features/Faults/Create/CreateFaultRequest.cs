namespace YurtYonetimSistemi.Application.Features.Faults.Create;

public record CreateFaultRequest(string Title,string Description,int studentUserId,int RoomId);

