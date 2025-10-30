

namespace YurtYonetimSistemi.Application.Contracts.Identity;

public interface IUserService
{
    Task<string?> GetFullNameByUserIdAsync(int userId);

}
