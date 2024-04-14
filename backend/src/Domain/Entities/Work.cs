using Common.Enums;
using Domain.Interfaces;

namespace Domain.Entities;

public class Work : IBaseEntity
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Student Student { get; set; } = null!;

    public Guid SubjectId { get; set; }

    public Subject Subject { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime Deadline { get; set; }

    public WorkStatus Status { get; set; }

    public ICollection<Subwork> Subworks { get; set; } = null!;
}
