using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext : IDisposable
{
    public DbSet<User> Users { get; }
    public DbSet<Contact> Contacts { get; }
    public DbSet<University> Universities { get; }
    public DbSet<Teacher> Teachers { get; }
    public DbSet<Student> Students { get; }
    public DbSet<Group> Groups { get; }
    public DbSet<Subject> Subjects { get; }
    public DbSet<SubjectToGroup> SubjectToGroups { get; }
    public DbSet<SubjectToTeacher> SubjectToTeachers { get; }
    public DbSet<Link> Links { get; }
    public DbSet<Comment> Comments { get; }
    public DbSet<Work> Works { get; }
    public DbSet<Subwork> Subworks { get; }

    public DatabaseFacade Database { get; }

    public DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
