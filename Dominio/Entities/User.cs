using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public RoleEnum Role { get; set; } = RoleEnum.EMPLOYEE;
    public Guid CountryId { get; set; }
    
    public Country Country { get; set; } = null!;
    public ICollection<ProjectAssignment> ProjectAssignments { get; set; } = [];
    public ICollection<DailyAttendance> DailyAttendances { get; set; } = [];
    public ICollection<Absence> Absences { get; set; } = [];
    public ICollection<Salary> Salaries { get; set; } = [];
    public ICollection<Payroll> Payrolls { get; set; } = [];
}

