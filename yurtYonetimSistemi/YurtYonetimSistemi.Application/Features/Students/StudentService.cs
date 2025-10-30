using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Users;

namespace YurtYonetimSistemi.Application.Features.Students;

public class StudentService(IStudentRepository studentRepository,
    IUnitOfWork unitOfWork,
    IUserService userService):IStudentService
{
    public async Task<ServiceResult<StudentDto>> GetStudentByIdAsync(int id)
    {
        var student = await studentRepository.GetByIdAsync(id);
        // Check if staff exists
        if (student is null)
        {
            return ServiceResult<StudentDto>.Fail("Student not found", HttpStatusCode.NotFound);
        }
        var fullName = await userService.GetFullNameByUserIdAsync(student.UserId);
        var studentDto = new StudentDto(
            student.Id,
            student.UserId,
            fullName!,
            student.RoomId,
            student.Department,
            student.University
        );
        return ServiceResult<StudentDto>.Success(studentDto);
    }
}
