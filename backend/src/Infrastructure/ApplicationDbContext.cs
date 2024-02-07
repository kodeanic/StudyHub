using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
#pragma warning disable CS8618
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore CS8618
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Host=localhost;Port=5433;Database=Assignment;Username=postgres;Password=password";
                //$"Host={_options.DbHost};Port={_options.DbPort};Database={_options.DbName};Username={_options.User};Password={_options.Password}";
                Log.Information($"Connect to database: {connectionString}");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
