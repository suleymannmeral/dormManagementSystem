using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;

namespace YurtYonetimSistemi.Application.Features.Faults;

public class FaultService(IFaultRepository faultRepository,
    IUnitOfWork unitOfWork):IFaultService
{
    //public async Task<ServiceResult<FaultDto>> GetFaultByIdAsync(int id)
    //{
    //    var fault = await faultRepository.GetByIdAsync(id);

    //    // Check if fault exists

    //    if (fault is null)
    //    {
    //        return ServiceResult<FaultDto>.Fail("Fault not found",HttpStatusCode.NotFound);
    //    }
    //    // Map Fault to FaultDto (Manual mapping)
    //    //var faultDto = new FaultDto(
    //    //    fault.Id,
    //    //    fault.Title,
    //    //    fault.Description,
    //    //    fault.StudentId,
    //    //    fault.RoomId,
    //    //    fault.
    //    //);
    //    return ServiceResult<FaultDto>.Success(faultDto);
    //}
}
