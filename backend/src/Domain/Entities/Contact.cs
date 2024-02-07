using Domain.Interfaces;

namespace Domain.Entities;

public class Contact : IBaseEntity
{
    public Guid Id { get; set; }

    public string Link { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public User User { get; set; }
}
