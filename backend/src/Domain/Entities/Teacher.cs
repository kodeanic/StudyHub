using Domain.Interfaces;

namespace Domain.Entities;

public class Teacher : IBaseEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid UniversityId { get; set; }

    public University University { get; set; } = null!;

    public ICollection<SubjectToTeacher> SubjectToTeachers { get; set; } = null!;

    public ICollection<Comment> Comments { get; set; } = null!;
}
