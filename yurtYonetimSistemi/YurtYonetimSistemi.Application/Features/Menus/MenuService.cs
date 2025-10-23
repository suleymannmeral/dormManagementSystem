using YurtYonetimSistemi.Application.Contracts.Persistence;

namespace YurtYonetimSistemi.Application.Features.Menus;

public class MenuService(IMenuRepository menuRepository,
    IUnitOfWork unitOfWork):IMenuService
{

}
