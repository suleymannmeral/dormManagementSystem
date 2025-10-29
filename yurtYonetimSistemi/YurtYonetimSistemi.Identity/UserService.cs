using Microsoft.AspNetCore.Identity;
using YurtYonetimSistemi.Application.Contracts.Identity;
using YurtYonetimSistemi.Identity.Models;

namespace YurtYonetimSistemi.Identity;

public class UserService:IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string?> GetFullNameByUserIdAsync(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        return user is null ? null : $"{user.FirstName} {user.LastName}";
    }
}
