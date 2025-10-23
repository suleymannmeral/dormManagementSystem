using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence.StudentLeaves;

public class StudentLeaveRepository(AppDbContext context):GenericRepository<StudentLeave,int>(context), IStudentLeaveRepository
{
}
