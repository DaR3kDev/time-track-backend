using Domain.Common;

namespace Domain.Entities;

public class MinimumWage : BaseEntity
{
    public Guid CountryId { get; set; }
    public decimal Amount { get; set; }
    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }

    public Country Country { get; set; } = null!;
}