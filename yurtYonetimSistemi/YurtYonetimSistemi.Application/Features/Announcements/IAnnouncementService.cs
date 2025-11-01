using YurtYonetimSistemi.Application.DTOs.Announcements;
using YurtYonetimSistemi.Application.Features.Announcements.Create;
using YurtYonetimSistemi.Application.Features.Announcements.Update;

namespace YurtYonetimSistemi.Application.Features.Announcements;

public interface IAnnouncementService
{
    Task<ServiceResult<AnnouncementDto>> GetByIdAsync(int id);
    Task<ServiceResult<CreateAnnouncementResponse>> CreateAsync(CreateAnnouncementRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateAnnouncementRequest request);
}
