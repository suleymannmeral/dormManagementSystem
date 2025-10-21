using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.Persistence.Faults;

public class FaultRepositoy(AppDbContext context):GenericRepository<Fault,int>(context),IFaultRepository
{
}
