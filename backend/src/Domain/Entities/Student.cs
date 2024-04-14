using Domain.Interfaces;

namespace Domain.Entities;

public class Student : IBaseEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid GroupId { get; set; }

    public Group Group { get; set; } = null!;

    public ICollection<Work> Works { get; set; } = null!;
}
