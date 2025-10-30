using Microsoft.AspNetCore.Identity;
using YurtYonetimSistemi.Application;
using YurtYonetimSistemi.Application.Features.Users;
using YurtYonetimSistemi.Application.Features.Users.Create;
using YurtYonetimSistemi.Identity.Models;

namespace YurtYonetimSistemi.Identity;

public class UserService(UserManager<ApplicationUser> userManager):IUserService
{
  
    public Task<ServiceResult<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> GetFullNameByUserIdAsync(int userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        return user is null ? null : $"{user.FirstName} {user.LastName}";
    }
}
