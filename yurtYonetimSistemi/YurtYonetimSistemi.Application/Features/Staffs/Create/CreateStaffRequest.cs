
namespace YurtYonetimSistemi.Application.Features.Staffs.Create;

public record CreateStaffRequest(string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Position,
    DateTime DateOfBirth,
    string UserName,
    string Password
    );
