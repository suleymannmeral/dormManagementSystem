namespace YurtYonetimSistemi.Application.Features.StudentLeaves.Create;

public record  CreateStudentLeaveRequest(int StudentId,DateTime StartDate,DateTime EndDate,string Reason);

