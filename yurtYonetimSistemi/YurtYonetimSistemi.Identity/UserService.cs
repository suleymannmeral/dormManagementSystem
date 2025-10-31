using Microsoft.AspNetCore.Identity;
using System.Net;
using YurtYonetimSistemi.Application;
using YurtYonetimSistemi.Application.Features.Staffs;
using YurtYonetimSistemi.Application.Features.Students;
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

    public async Task<ServiceResult<UserDto>> GetUserByUsername(string userName)
    {
       var user= await userManager.FindByNameAsync(userName);

        if(user is null)
            return ServiceResult<UserDto>.Fail("User not found", HttpStatusCode.NotFound);

        var userDto = new UserDto(
            UserId: user.Id,
            UserName: user.UserName!,
            FullName: user.FirstName + " " + user.LastName,
            Email:user.Email!,
            Phone:user.PhoneNumber!
            );
           
        return ServiceResult<UserDto>.Success(userDto);



    }
}
