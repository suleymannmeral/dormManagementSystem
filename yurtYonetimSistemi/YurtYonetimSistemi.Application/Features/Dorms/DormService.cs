using YurtYonetimSistemi.Application.Contracts.Persistence;

namespace YurtYonetimSistemi.Application.Features.Dorms;

public class DormService(IDormRepository dormRepository,
    IUnitOfWork unitOfWork):IDormService
{

}
