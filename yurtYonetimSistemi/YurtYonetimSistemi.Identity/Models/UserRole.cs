

using System.ComponentModel.DataAnnotations;

namespace YurtYonetimSistemi.Identity.Models;

public class UserRole
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
}
