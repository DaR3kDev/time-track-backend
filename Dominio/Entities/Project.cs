using Domain.Common;

namespace Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = null;

    // Relaciones
    public ICollection<ProjectAssignment> ProjectAssignments { get; set; } = [];
    public ICollection<WorkLog> WorkLogs { get; set; } = [];
}
