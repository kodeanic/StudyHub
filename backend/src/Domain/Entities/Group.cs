using Domain.Interfaces;

namespace Domain.Entities;

public class Group : IBaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid UniversityId { get; set; }

    public University University { get; set; }

    public ICollection<User> Students { get; set; }

    public ICollection<Semester> Semesters { get; set; }
}
