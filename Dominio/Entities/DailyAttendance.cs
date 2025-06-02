
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class DailyAttendance : BaseEntity
{
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public AttendanceStatusEnum Status { get; set; }
    public WorkTypeEnum? WorkType { get; set; }
    public decimal? TotalHours { get; set; }
    public decimal? CalculatedPay { get; set; }

    // Relaciones
    public User User { get; set; } = null!;
}

