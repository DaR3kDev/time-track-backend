
using Domain.Common;

namespace Domain.Entities;

public class Salary : BaseEntity
{
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }
    public bool IsHourly { get; set; } = true;
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }

    public User User { get; set; } = null!;
}

