using YurtYonetimSistemi.Application.Contracts.Persistence;

namespace YurtYonetimSistemi.Application.Features.Faults;

public class FaultService(IFaultRepository faultRepository,
    IUnitOfWork unitOfWork):IFaultService
{
}
