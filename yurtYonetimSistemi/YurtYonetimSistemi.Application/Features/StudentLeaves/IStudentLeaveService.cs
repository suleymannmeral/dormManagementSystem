using YurtYonetimSistemi.Application.Features.StudentLeaves.Create;

namespace YurtYonetimSistemi.Application.Features.StudentLeaves;

public interface IStudentLeaveService
{
    Task<ServiceResult<StudentLeaveDto>> GetByIdAsync(int id);
    Task<ServiceResult<CreateStudentLeaveResponse>> CreateAsync(CreateStudentLeaveRequest request);
}
