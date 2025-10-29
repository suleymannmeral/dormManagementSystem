
using YurtYonetimSistemi.Domain.Entities;

namespace YurtYonetimSistemi.Application.Contracts.Persistence;

public interface IStudentRepository:IGenericRepository<Student,int>
{
    Task<List<Student>> GetStudentsByRoomIdAsync(int roomId);

}
