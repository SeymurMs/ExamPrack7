using ExamPrak7.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamPrak7.DAL
{
    public class AppDbContext:IdentityDbContext<Appuser>
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
    }
}
