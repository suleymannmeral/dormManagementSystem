namespace YurtYonetimSistemi.Application.Features.Faults;
public interface IFaultService
{
    Task<ServiceResult<FaultDto>> GetFaultByIdAsync(int id);
}
