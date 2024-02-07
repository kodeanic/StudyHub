using Domain.Interfaces;

namespace Domain.Entities;

public class University : IBaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public ICollection<Group> Groups { get; set; }
}
