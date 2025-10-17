using YurtYonetimSistemi.Domain.Entities.Common;

namespace YurtYonetimSistemi.Domain.Entities;

public class Announcement:BaseEntity<int>
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

}
