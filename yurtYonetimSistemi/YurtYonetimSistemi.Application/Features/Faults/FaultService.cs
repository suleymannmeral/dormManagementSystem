using System.Net;
using YurtYonetimSistemi.Application.Contracts.Identity;
using YurtYonetimSistemi.Application.Contracts.Persistence;

namespace YurtYonetimSistemi.Application.Features.Faults;

public class FaultService(IFaultRepository _faultRepository,
    IUnitOfWork _unitOfWork,
    IUserService _userService
    ):IFaultService
{
    public async Task<ServiceResult<FaultDto>> GetFaultByIdAsync(int id)
    {
        var fault = await _faultRepository.GetByIdAsync(id);
        if (fault == null)
            return ServiceResult<FaultDto>.Fail("Not found");

        var fullName = await _userService.GetFullNameByUserIdAsync(fault.Student.UserId);

        //manually mapping
        var dto = new FaultDto(
            fault.Id,
            fault.Title,
            fault.Description,
            fault.StudentId,
            fault.RoomId,
            fullName ?? "Bilinmiyor"
        );

        return ServiceResult<FaultDto>.Success(dto);
    }
}
