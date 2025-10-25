using YurtYonetimSistemi.Domain.Entities.Common;
using YurtYonetimSistemi.Domain.Entities.Enums;

namespace YurtYonetimSistemi.Domain.Entities;

public sealed class StudentLeave:BaseEntity<int>
{
    public int StudentId { get; set; } 
    public DateTime StartDate { get; set; }  
    public DateTime EndDate { get; set; }  
    public string Reason { get; set; } = null!; 
    public LeaveStatus Status { get; set; }  
    public DateTime RequestDate { get; set; } = DateTime.UtcNow; 
    public Student Student { get; set; } = null!;
}
