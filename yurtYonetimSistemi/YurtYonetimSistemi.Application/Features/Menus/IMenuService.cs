namespace YurtYonetimSistemi.Application.Features.Menus;

public interface IMenuService
{
    Task<ServiceResult<MenuDto>> GetMenuByIdAsync(int id);
}
