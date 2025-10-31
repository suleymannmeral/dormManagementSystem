
namespace YurtYonetimSistemi.Application.Features.Users;

public record UserDto(
    int UserId,
    string UserName,
    string FullName,
    string Email,
    string Phone
    );

