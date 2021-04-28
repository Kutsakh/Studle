
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Studle.DAL.Entities;

namespace Studle.DAL.EF
{
<<<<<<< HEAD
    public class AppDbContext : IdentityDbContext<WEBUser>
    {
        public DbSet<User> Guests { get; set; }
=======
    
        public DbSet<Group> Groups { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Topic> Topics { get; set; }

<<<<<<< HEAD
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
=======
        public DbSet<Mark> Marks { get; set; }
>>>>>>> cf253ac75b7a2f9307a8a4a78f810b0d18e40087

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
