using YurtYonetimSistemi.Application.DTOs.Dorms;

namespace YurtYonetimSistemi.Application.Features.Dorms;

public interface IDormService
{
    Task<ServiceResult<DormDto>> GetDormByIdAsync(int id);

}
