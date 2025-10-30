using YurtYonetimSistemi.Application.Features.Announcements.Create;

namespace YurtYonetimSistemi.Application.Features.Announcements;

public interface IAnnouncementService
{
    Task<ServiceResult<AnnouncementDto>> GetByIdAsync(int id);
    Task<ServiceResult<CreateAnnouncementResponse>> CreateAsync(CreateAnnouncementRequest request);
}
