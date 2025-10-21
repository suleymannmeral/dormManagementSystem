using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence.Students;

public class StudentRepository(AppDbContext context): GenericRepository<Student, int>(context), IStudentRepository
{
}
