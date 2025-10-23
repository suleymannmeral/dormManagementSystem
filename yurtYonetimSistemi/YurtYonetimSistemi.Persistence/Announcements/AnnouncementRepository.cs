
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence;

public class AnnouncementRepository(AppDbContext context) : GenericRepository<Announcement, int>(context), IAnnouncementRepository
{
 
}
