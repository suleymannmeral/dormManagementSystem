using YurtYonetimSistemi.Application.Features.Students.Create;
using YurtYonetimSistemi.Application.Features.Users.Create;

namespace YurtYonetimSistemi.Application.Features.Students;

public interface IStudentService
{
    Task<ServiceResult<StudentDto>> GetStudentByIdAsync(int id);
    Task<ServiceResult<CreateStudentResponse>> CreateAsync(CreateStudentRequest request, CreateUserRequest requestUser);

}
