
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Holiday : BaseEntity
{
    public Guid? DepartmentId { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public HolidayTypeEnum Type { get; set; } = HolidayTypeEnum.NATIONAL;
    
    public Country Country { get; set; } = null!;
    public Department? Department { get; set; }
}

