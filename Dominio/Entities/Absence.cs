using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Absence : BaseEntity
{
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }
    public AbsenceReasonEnum Reason { get; set; }
    public string? Notes { get; set; }

    public User User { get; set; } = null!;
}

