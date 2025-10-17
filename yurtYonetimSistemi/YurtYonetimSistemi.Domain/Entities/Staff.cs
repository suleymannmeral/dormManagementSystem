using YurtYonetimSistemi.Domain.Entities.Common;

namespace YurtYonetimSistemi.Domain.Entities;

public class Staff:BaseEntity<int>
{
    public int UserId { get; set; } // Foreign Key to User entity
}
