using YurtYonetimSistemi.Application.DTOs.Faults.Create;
using YurtYonetimSistemi.Application.Features.Faults.Update;
using YurtYonetimSistemi.Application.Features.Faults.UpdateFault;

namespace YurtYonetimSistemi.Application.Features.Faults;
public interface IFaultService
{
    Task<ServiceResult<FaultDto>> GetByIdAsync(int id);
    Task<ServiceResult<CreateFaultResponse>> CreateAsync(CreateFaultRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateFaultRequest request);
    Task<ServiceResult> UpdateStatusAsync(int id, UpdateFaultStatusRequest request);
    
 }
