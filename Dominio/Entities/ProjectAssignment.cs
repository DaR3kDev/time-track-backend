using Domain.Common;

namespace Domain.Entities;

public class ProjectAssignment : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    // Relaciones
    public User User { get; set; } = null!;
    public Project Project { get; set; } = null!;
}
