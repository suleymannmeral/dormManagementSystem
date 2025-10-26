using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;

namespace YurtYonetimSistemi.Application.Features.Announcements;

public class AnnouncementService(IAnnouncementRepository announcementRepository,
    IUnitOfWork unitOfWork):IAnnouncementService
{
    public async Task<ServiceResult<AnnouncementDto>> GetAnnouncementByIdAsync(int id)
    {
        var announcement = await announcementRepository.GetByIdAsync(id);

        // Check if announcement exists
        if (announcement is null)
        {
            return ServiceResult<AnnouncementDto>.Fail("Announcement not found",HttpStatusCode.NotFound);
        }
        // Map Announcement to AnnouncementDto (Manual mapping)
        var announcementDto = new AnnouncementDto(
            announcement.Id,
            announcement.Title,
            announcement.Description
        );

        return ServiceResult<AnnouncementDto>.Success(announcementDto);
    }
}
