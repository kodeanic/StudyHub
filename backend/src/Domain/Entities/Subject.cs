﻿using Domain.Interfaces;

namespace Domain.Entities;

public class Subject : IBaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<SubjectToGroup> SubjectToGroups { get; set; } = null!;

    public ICollection<SubjectToTeacher> SubjectToTeachers { get; set; } = null!;

    public ICollection<Comment> Comments { get; set; } = null!;

    public ICollection<Work> Works { get; set; } = null!;
}
