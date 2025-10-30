using System.Net;
using System.Reflection;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.DTOs.Announcements;
using YurtYonetimSistemi.Application.Features.Announcements.Create;
using YurtYonetimSistemi.Domain.Entities;

namespace YurtYonetimSistemi.Application.Features.Announcements;

public class AnnouncementService(IAnnouncementRepository announcementRepository,
    IUnitOfWork unitOfWork):IAnnouncementService
{
    public async Task<ServiceResult<AnnouncementDto>> GetByIdAsync(int id)
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

    public async Task<ServiceResult<CreateAnnouncementResponse>> CreateAsync(CreateAnnouncementRequest request)
    {
        // Create new Announcement entity manually
        var announcement = new Announcement()
        {
            Title = request.Title,
            Description = request.Description

        };
            
        await announcementRepository.AddAsync(announcement);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateAnnouncementResponse>.Success(new CreateAnnouncementResponse(announcement.Id));
    }


}
