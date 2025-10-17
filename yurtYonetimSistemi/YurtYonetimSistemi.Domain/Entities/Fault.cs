
using YurtYonetimSistemi.Domain.Entities.Common;

namespace YurtYonetimSistemi.Domain.Entities;

public sealed class Fault : BaseEntity<int>
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int StudentId { get; set; }
    public int RoomId { get; set; }
    public Student Student { get; set; } = null!;
    public Room Room { get; set; } = null!;
}
