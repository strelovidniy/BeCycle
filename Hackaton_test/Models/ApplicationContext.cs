using Microsoft.EntityFrameworkCore;

namespace Hackaton_test.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Poster> Posters { get; set; }
        //public DbSet<Achievement> Achievements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WORKSTATION\WORKSTATION; Database=HackatonDB; Trusted_Connection=True");
        }
    }
}
