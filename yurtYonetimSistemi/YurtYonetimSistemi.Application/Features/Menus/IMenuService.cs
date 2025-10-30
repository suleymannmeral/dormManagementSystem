using YurtYonetimSistemi.Application.Features.Menus.Create;

namespace YurtYonetimSistemi.Application.Features.Menus;

public interface IMenuService
{
    Task<ServiceResult<MenuDto>> GetMenuByIdAsync(int id);
    Task<ServiceResult<CreateMenuResponse>> CreateAsync(CreateMenuRequest request);
}
