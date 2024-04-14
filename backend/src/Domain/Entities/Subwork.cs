using Domain.Interfaces;

namespace Domain.Entities;

public class Subwork : IBaseEntity
{
    public Guid Id { get; set; }

    public Guid WorkId { get; set; }

    public Work Work { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}
