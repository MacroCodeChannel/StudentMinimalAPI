using Microsoft.EntityFrameworkCore;
using StudentMinimalAPI.StudentAPIModels;

namespace StudentMinimalAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

    }
}
