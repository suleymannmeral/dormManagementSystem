using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.DTOs.Dorms;

namespace YurtYonetimSistemi.Application.Features.Dorms;

public class DormService(IDormRepository dormRepository,
    IUnitOfWork unitOfWork):IDormService
{

    public async Task<ServiceResult<DormDto>> GetDormByIdAsync(int id)
    {
        var dorm = await dormRepository.GetByIdAsync(id);

        // Check if dorm exists

        if (dorm is null)
        {
            return ServiceResult<DormDto>.Fail("Dorm not found",HttpStatusCode.NotFound);
        }

        // Map Dorm to DormDto (Manual mapping)

        var dormDto = new DormDto(
            dorm.Id,
            dorm.Name,
            dorm.Address,
            dorm.PhoneNumber,
            dorm.Email
        );

        return ServiceResult<DormDto>.Success(dormDto);
    }

}
