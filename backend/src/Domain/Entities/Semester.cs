using Domain.Interfaces;

namespace Domain.Entities;

public class Semester : IBaseEntity
{
    public Guid Id { get; set; }

    public short Number { get; set; }

    public Guid GroupId { get; set; }

    public Group Group { get; set; }
}
