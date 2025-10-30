namespace YurtYonetimSistemi.Application.Features.StudentLeaves.Create;

public record  CreateStudentLeaveRequest(int StudentUserId,DateTime StartDate,DateTime EndDate,string Reason);

