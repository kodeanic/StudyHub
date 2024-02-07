using Domain.Interfaces;

namespace Domain.Entities;

public class Subject : IBaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid SemesterId { get; set; }

    public Semester Semester { get; set; }
}
