using System.Net;
using YurtYonetimSistemi.Application.Contracts.Identity;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Students;

namespace YurtYonetimSistemi.Application.Features.StudentLeaves;

public class StudentLeaveService(IStudentLeaveRepository studentLeaveRepository,
    IUnitOfWork unitOfWork,
    IUserService userService
    ) :IStudentLeaveService
{
    public async Task<ServiceResult<StudentLeaveDto>> GetStudentLeaveByIdAsync(int id)
    {
        var studentLeave = await studentLeaveRepository.GetByIdAsync(id);
        if (studentLeave is null)

        {
            return ServiceResult<StudentLeaveDto>.Fail("StudentLeave not found", HttpStatusCode.NotFound);
        }
        var studentName= await userService.GetFullNameByUserIdAsync(studentLeave.Student.UserId);

        var studentLeaveDto = new StudentLeaveDto(
            studentLeave.Id,
            studentLeave.StudentId,
            studentLeave.StartDate,
            studentLeave.EndDate,
            studentLeave.Reason,
            studentLeave.Status,
            studentLeave.RequestDate,
            studentName!
         
        );
        return ServiceResult<StudentLeaveDto>.Success(studentLeaveDto);
    }
}
