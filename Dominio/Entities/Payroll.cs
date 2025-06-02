using Domain.Common;

namespace Domain.Entities;
public class Payroll : BaseEntity
{
    public Guid UserId { get; set; }
    public DateOnly PeriodStart { get; set; }
    public DateOnly PeriodEnd { get; set; }
    public decimal BaseAmount { get; set; }
    public decimal OvertimeAmount { get; set; } = 0.00m;
    public decimal Deductions { get; set; } = 0.00m;
    public decimal TotalPaid { get; set; }
    public DateTime? PaidAt { get; set; }
    public string? Notes { get; set; }

    public User User { get; set; } = null!;
}

