using Microsoft.EntityFrameworkCore;
using Studle.DAL.Entities;

namespace Studle.DAL.EF
{
    public class AppDbContext : DbContext
    { 
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=studle.db");

        // TODO: update
        // public AppDbContext(string connectionString)
        //     : base(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(@connectionString).Options)
        // {
        //     Database.EnsureCreated();
        // }
        //
        // public AppDbContext(DbContextOptions<AppDbContext> options)
        //     : base(options)
        // {
        //     Database.EnsureCreated();
        // }
    }
}