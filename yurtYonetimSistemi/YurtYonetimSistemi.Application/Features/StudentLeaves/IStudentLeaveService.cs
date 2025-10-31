namespace YurtYonetimSistemi.Application.Features.StudentLeaves;

public interface IStudentLeaveService
{
    Task<ServiceResult<StudentLeaveDto>> GetByIdAsync(int id);
}
