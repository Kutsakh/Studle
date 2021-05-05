using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Studle.DAL.Entities;

namespace Studle.DAL.EF
{

    public class AppDbContext : IdentityDbContext<User, Role, int>
    {    
        public DbSet<Group> Groups { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Role> Role { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public AppDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("FileName=studle.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group>()
                .HasMany(c => c.Subjects)
                .WithMany(s => s.Groups)
                .UsingEntity(j => j.ToTable("GroupHasSubjects"));
        }
    }
}
