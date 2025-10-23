using YurtYonetimSistemi.Application.Contracts.Persistence;

namespace YurtYonetimSistemi.Application.Features.Announcements;

public class AnnouncementService(IAnnouncementRepository announcementRepository,
    IUnitOfWork unitOfWork):IAnnouncementService
{
}
