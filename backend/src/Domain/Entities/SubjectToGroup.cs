namespace Domain.Entities;

public class SubjectToGroup
{
    public Guid Id { get; set; }

    public Guid SubjectId { get; set; }

    public Subject Subject { get; set; } = null!;

    public Guid GroupId { get; set; }

    public Group Group { get; set; } = null!;

    public short SemesterNumber { get; set; }

    public ICollection<Link> Links { get; set; } = null!;
}
