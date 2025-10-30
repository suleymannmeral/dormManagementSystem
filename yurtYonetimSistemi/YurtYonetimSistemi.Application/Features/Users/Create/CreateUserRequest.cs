

namespace YurtYonetimSistemi.Application.Features.Users.Create;

public record CreateUserRequest(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string UserName,
    string Email,
    string Password,
    string PhoneNumber
);
