using Application.Common.Mapping;
using Domain.Entities;

namespace Application.Requests.Users;

public class UserDto : IMapFrom<User>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Patronymic { get; set; } = string.Empty;

    public ICollection<Contact> Contacts { get; set; } = null!;

    public Guid? StudentId { get; set; }

    public Guid? TeacherId { get; set; }
}
