namespace YurtYonetimSistemi.Application.Features.StudentLeaves.Update;

public record UpdateStudentLeaveRequest(DateTime StartDate, DateTime EndDate, string Reason);

