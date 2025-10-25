using YurtYonetimSistemi.Domain.Entities.Enums;

namespace YurtYonetimSistemi.Application.Features.StudentLeaves;

public record StudentLeaveDto(
    int Id,
    int StudentId,
    DateTime StartDate,
    DateTime EndDate,
    string Reason,
    LeaveStatus Status,
    DateTime RequestDate,
    string StudentName
    );
