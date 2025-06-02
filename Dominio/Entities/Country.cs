
using Domain.Common;

namespace Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
 
    public ICollection<User> Users { get; set; } = [];
    public ICollection<Department> Departments { get; set; } = [];
    public ICollection<Holiday> Holidays { get; set; } = [];
    public ICollection<MinimumWage> MinimumWages { get; set; } = [];
}

