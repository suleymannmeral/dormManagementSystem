using YurtYonetimSistemi.Application.Contracts.Persistence;

namespace YurtYonetimSistemi.Application.Features.Students;

public class StudentService(IStudentRepository studentRepository,
    IUnitOfWork unitOfWork):IStudentService
{
}
