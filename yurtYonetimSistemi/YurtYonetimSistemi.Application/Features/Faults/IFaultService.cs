using YurtYonetimSistemi.Application.Features.Faults.Create;

namespace YurtYonetimSistemi.Application.Features.Faults;
public interface IFaultService
{
    Task<ServiceResult<FaultDto>> GetByIdAsync(int id);
    Task<ServiceResult<CreateFaultResponse>> CreateAsync(CreateFaultRequest request);
}
