using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Students.Create;
using YurtYonetimSistemi.Application.Features.Users;
using YurtYonetimSistemi.Application.Features.Users.Create;
using YurtYonetimSistemi.Domain.Entities;

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

    public async Task<ServiceResult<CreateStudentResponse>> CreateAsync(CreateStudentRequest request, CreateUserRequest requestUser)
    {

        var anyUser = await userService.GetUserByUsername(requestUser.UserName);

        if (anyUser is not null)
        {
            return ServiceResult<CreateStudentResponse>.Fail("Username already exist", HttpStatusCode.BadRequest);

        }

        var userResult = await userService.CreateUserAsync(requestUser);

        if (!userResult.IsSuccess)
            return ServiceResult<CreateStudentResponse>.Fail(userResult.ErrorMessage!);

        var student = new Student()
        {
            UserId = userResult.Data!.UserId,
            Department=request.Department,
            RoomId=request.RoomNumber
        };

        await studentRepository.AddAsync(student);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateStudentResponse>.Success(new CreateStudentResponse(student.Id));
    }

}
