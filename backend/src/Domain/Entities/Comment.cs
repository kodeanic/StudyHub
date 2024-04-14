using Domain.Interfaces;

namespace Domain.Entities;

public class Comment : IBaseEntity
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }

    public Teacher? Teacher { get; set; }

    public Guid? SubjectId { get; set; }

    public Subject? Subject { get; set; }

    public DateTime Time { get; set; }

    public string Text { get; set; } = string.Empty;
}
