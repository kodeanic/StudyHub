using Domain.Interfaces;

namespace Domain.Entities;

public class User : IBaseEntity
{
    public Guid Id { get; set; }

    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Patronymic { get; set; } = string.Empty;

    public ICollection<Contact> Contacts { get; set; } = null!;

    public Guid? StudentId { get; set; }

    public Student? Student { get; set; }

    public Guid? TeacherId { get; set; }

    public Teacher? Teacher { get; set; }
}
