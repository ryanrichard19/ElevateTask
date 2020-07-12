using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionToken>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

       


        }

        public DbSet<SessionToken> SessionTokens { get; set; }
    }
}