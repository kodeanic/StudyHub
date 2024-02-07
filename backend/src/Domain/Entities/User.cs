using Domain.Interfaces;

namespace Domain.Entities;

public class User : IBaseEntity
{
    public Guid Id { get; set; }

    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public int Role { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public ICollection<Contact> Contacts { get; set; }

    public Guid? GroupId { get; set; }

    public Group? Group { get; set; }
}
