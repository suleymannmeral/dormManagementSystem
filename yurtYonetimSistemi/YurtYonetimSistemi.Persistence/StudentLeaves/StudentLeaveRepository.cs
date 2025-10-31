using Microsoft.EntityFrameworkCore;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Domain.Entities.Enums;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence.StudentLeaves;

public class StudentLeaveRepository(AppDbContext context):GenericRepository<StudentLeave,int>(context), IStudentLeaveRepository
{
    public async Task<bool> AnyActiveLeaveByStudentIdAsync(int studentId)
    {
        var now = DateTime.Now;

        return await context.StudentLeaves
            .AnyAsync(x => x.StudentId == studentId
                           && x.StartDate <= now
                           && x.EndDate >= now
                           && x.Status != LeaveStatus.Cancelled);
    }

}
