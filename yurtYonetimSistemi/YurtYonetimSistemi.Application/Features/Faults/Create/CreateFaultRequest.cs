using YurtYonetimSistemi.Domain.Entities.Enums;

namespace YurtYonetimSistemi.Application.DTOs.Faults.Create;

public record CreateFaultRequest(string Title,string Description,int studentId,int RoomId);

