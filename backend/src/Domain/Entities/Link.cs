using Domain.Interfaces;

namespace Domain.Entities;

public class Link : IBaseEntity
{
    public Guid Id { get; set; }

    public string Data { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid SubjectToGroupId { get; set; }

    public SubjectToGroup SubjectToGroup { get; set; } = null!;
}
