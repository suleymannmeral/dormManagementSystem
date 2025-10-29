using Microsoft.EntityFrameworkCore;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence.Students;

public class StudentRepository(AppDbContext context): GenericRepository<Student, int>(context), IStudentRepository
{
    public async Task<List<Student>> GetStudentsByRoomIdAsync(int roomId)
    {
        return await context.Students
            .Where(s => s.RoomId == roomId)
            .ToListAsync();
    }
}
