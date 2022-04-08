using Microsoft.EntityFrameworkCore;
using Task5.Entites;

namespace Task5.DATA
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}