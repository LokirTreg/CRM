using CRM.WEB.Models.Entyties;
using Microsoft.EntityFrameworkCore;

namespace CRM.WEB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Сlassroom> Сlassrooms { get; set; }
        public DbSet<Course_Teacher> Course_Teachers { get; set; }
        public DbSet<Group_Student> Group_Students { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
