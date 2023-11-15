using BulkinaAnnaKT_31_20.Database.Configurations;
using BulkinaAnnaKT_31_20.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkinaAnnaKT_31_20.Database
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }
        public StudentDbContext(DbContextOptions options) : base(options) { }
    }
}
