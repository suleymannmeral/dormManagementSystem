using YurtYonetimSistemi.Domain.Entities;

namespace YurtYonetimSistemi.Application.Contracts.Persistence;

public interface IStudentLeaveRepository:IGenericRepository<StudentLeave,int>
{
    Task<bool> AnyActiveLeaveByStudentIdAsync(int studentId);
}
