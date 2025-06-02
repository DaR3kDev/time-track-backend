using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class WorkLog : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid? ProjectId { get; set; }
    public DateOnly WorkDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public decimal? TotalHours { get; set; }
    public WorkTypeEnum Type { get; set; } = WorkTypeEnum.NORMAL;
    public string? Notes { get; set; }

        
    // Relaciones 
    public User User { get; set; } = null!;
    public Project? Project { get; set; }
}
