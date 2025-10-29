namespace YurtYonetimSistemi.Application.Features.Announcements;

public interface IAnnouncementService
{
    Task<ServiceResult<AnnouncementDto>> GetAnnouncementByIdAsync(int id);
}
