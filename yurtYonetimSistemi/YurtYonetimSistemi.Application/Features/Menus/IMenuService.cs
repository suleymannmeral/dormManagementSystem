using YurtYonetimSistemi.Application.Features.Menus.Create;
using YurtYonetimSistemi.Application.Features.Menus.Update;

namespace YurtYonetimSistemi.Application.Features.Menus;

public interface IMenuService
{
    Task<ServiceResult<MenuDto>> GetMenuByIdAsync(int id);
    Task<ServiceResult<CreateMenuResponse>> CreateAsync(CreateMenuRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateMenuRequest request);
}
