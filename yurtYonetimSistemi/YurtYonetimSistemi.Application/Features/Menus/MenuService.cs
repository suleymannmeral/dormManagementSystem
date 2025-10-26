using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;

namespace YurtYonetimSistemi.Application.Features.Menus;

public class MenuService(IMenuRepository menuRepository,
    IUnitOfWork unitOfWork):IMenuService
{
    public async Task<ServiceResult<MenuDto>> GetMenuByIdAsync(int id)
    {
        var menu = await menuRepository.GetByIdAsync(id);
        // Check if menu exists
        if (menu is null)
        {
            return ServiceResult<MenuDto>.Fail("Menu not found",HttpStatusCode.NotFound);
        }

        // Map Menu to MenuDto (Manual mapping)
        var menuDto = new MenuDto(
            menu.Id,
            menu.Date,
            menu.MealTime,
            menu.Meals.Select(m => new MealDto(
                m.Id,
                m.Name,
                m.Type,
                m.MenuId
            )).ToList()
        );

        return ServiceResult<MenuDto>.Success(menuDto);
    }

}
