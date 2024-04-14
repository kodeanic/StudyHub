﻿namespace Domain.Entities;

public class SubjectToTeacher
{
    public Guid SubjectId { get; set; }

    public Subject Subject { get; set; } = null!;

    public Guid TeacherId { get; set; }

    public Teacher Teacher { get; set; } = null!;
}
