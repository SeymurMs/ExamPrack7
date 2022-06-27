using ExamPrak7.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamPrak7.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
    }
}
