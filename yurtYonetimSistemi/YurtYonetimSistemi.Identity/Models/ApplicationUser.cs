
using Microsoft.AspNetCore.Identity;

namespace YurtYonetimSistemi.Identity.Models;

public class ApplicationUser:IdentityUser<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
