namespace YurtYonetimSistemi.Application.Features.Users.Update;

public record UpdateUserRequest(string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string Username,
    string Email,
    string Password,
    string PhoneNumber
    );
