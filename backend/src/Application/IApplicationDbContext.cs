using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IApplicationDbContext : IDisposable
    {
        public DbSet<User> Users { get; }
        public DbSet<Contact> Contacts { get; }
        public DbSet<University> Universities { get; }
        public DbSet<Group> Groups { get; }
        public DbSet<Semester> Semesters { get; }
        public DbSet<Subject> Subjects { get; }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
