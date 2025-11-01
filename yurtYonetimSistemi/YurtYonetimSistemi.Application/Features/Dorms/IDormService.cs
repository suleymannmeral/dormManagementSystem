using YurtYonetimSistemi.Application.Features.Dorms.Update;

namespace YurtYonetimSistemi.Application.Features.Dorms;

public interface IDormService
{
    Task<ServiceResult<DormDto>> GetDormByIdAsync(int id);
    Task<ServiceResult> UpdateAsync(int id, UpdateDormRequest request);

}
