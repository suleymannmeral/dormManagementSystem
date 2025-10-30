using System.Net;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Application.Features.Menus.Create;
using YurtYonetimSistemi.Domain.Entities;

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
    public async Task<ServiceResult<CreateMenuResponse>> CreateAsync(CreateMenuRequest request)
    {
        // Create new Menu entity manually
        var menu = new Menu()
        {
          Date = request.Date,
          MealTime = request.MealTime
        };

        await menuRepository.AddAsync(menu);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateMenuResponse>.Success(new CreateMenuResponse(menu.Id));
    }




}
