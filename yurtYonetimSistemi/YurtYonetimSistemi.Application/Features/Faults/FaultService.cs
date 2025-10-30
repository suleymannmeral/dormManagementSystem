using System.Net;
using YurtYonetimSistemi.Application.Contracts.Identity;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Announcements.Create;
using YurtYonetimSistemi.Application.Features.Faults.Create;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Domain.Entities.Enums;

namespace YurtYonetimSistemi.Application.Features.Faults;

public class FaultService(IFaultRepository faultRepository,
    IUnitOfWork unitOfWork,
    IUserService userService
    ):IFaultService
{
    public async Task<ServiceResult<FaultDto>> GetByIdAsync(int id)
    {
        var fault = await faultRepository.GetByIdAsync(id);
        if (fault == null)
            return ServiceResult<FaultDto>.Fail("Not found");

        var fullName = await userService.GetFullNameByUserIdAsync(fault.Student.UserId);

        //manually mapping
        var faultDto = new FaultDto(
            fault.Id,
            fault.Title,
            fault.Description,
            fault.StudentId,
            fault.RoomId,
            fullName ?? "Bilinmiyor"
        );

        return ServiceResult<FaultDto>.Success(faultDto);
    }

    public async Task<ServiceResult<CreateFaultResponse>> CreateAsync(CreateFaultRequest request)
    {
        // Create new Fault entity manually
        var fault = new Fault()             
        {
           Title = request.Title,
           Description=request.Description,
           StudentId=request.studentId,
           RoomId=request.RoomId,
           Status=FaultStatus.Pending,
        };

        await faultRepository.AddAsync(fault);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateFaultResponse>.Success(new CreateFaultResponse(fault.Id));
    }

}
