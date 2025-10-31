using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Students;
using YurtYonetimSistemi.Application.Features.Users;

namespace YurtYonetimSistemi.Application.Features.StudentLeaves;

public class StudentLeaveService(IStudentLeaveRepository studentLeaveRepository,IUserService userService):IStudentLeaveService
{

    public async Task<ServiceResult<StudentLeaveDto>> GetByIdAsync(int id)
    {
        var studentLeave = await studentLeaveRepository.GetByIdAsync(id);
        // Check if staff exists
        if (studentLeave is null)
        {
            return ServiceResult<StudentLeaveDto>.Fail("StudentLeave not found", HttpStatusCode.NotFound);
        }
        var fullName = await userService.GetFullNameByUserIdAsync(studentLeave.Student.UserId);
        var studentLeaveDto = new StudentLeaveDto(
            Id:studentLeave.Id,
            StudentId:studentLeave.StudentId,
            StartDate:studentLeave.StartDate,
            EndDate:studentLeave.EndDate,
            Reason:studentLeave.Reason,
            Status:studentLeave.Status,
            RequestDate:studentLeave.RequestDate,
            StudentName:fullName!
        );
        return ServiceResult<StudentLeaveDto>.Success(studentLeaveDto);
    }
}
