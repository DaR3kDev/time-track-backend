using Domain.Common;

namespace Domain.Entities;

public class Department : BaseEntity
{
    public string? Name { get; set; }
    public Guid CountryId { get; set; }
    public Country Country { get; set; } = null!;

    public ICollection<Holiday> Holidays { get; set; } = [];

}
