using YurtYonetimSistemi.Application.Features.Users.Create;

namespace YurtYonetimSistemi.Application.Features.Users;

public interface IUserService
{
    Task<string?> GetFullNameByUserIdAsync(int userId);
    Task<ServiceResult<CreateUserResponse>> CreateUserAsync(CreateUserRequest request);


}
