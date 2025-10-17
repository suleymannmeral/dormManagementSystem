using YurtYonetimSistemi.Domain.Entities.Common;

namespace YurtYonetimSistemi.Domain.Entities;

public sealed class Room : BaseEntity<int>
{
    public string RoomNumber { get; set; } = null!;
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Fault> Faults { get; set; } = new List<Fault>();
}
