using YurtYonetimSistemi.Domain.Entities.Common;

namespace YurtYonetimSistemi.Domain.Entities;

public class Student : BaseEntity<int>
{
    public int UserId { get; set; }
    public int RoomId { get; set; }
    public string Department { get; set; } = null!;
    public string University { get; set; } = null!;
    public Room Room { get; set; } = null!;
    public ICollection<Fault> Faults { get; set; } = new List<Fault>();
}
