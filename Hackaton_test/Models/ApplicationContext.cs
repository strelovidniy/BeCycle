using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackaton_test.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Poster> Posters { get; set; }

        public DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PosterConfiguration());
            modelBuilder.ApplyConfiguration(new AchievementConfiguration());

        }

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JHQRTRT; Database=HackatonDB; Trusted_Connection=True");
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("User");
            modelBuilder.Property(n => n.NickName).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.City).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.FirstName).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.LastName).HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.Email).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.PhoneNumber).HasColumnType("nvarchar(15)");
        }
    }

    public class PosterConfiguration : IEntityTypeConfiguration<Poster>
    {
        public void Configure(EntityTypeBuilder<Poster> modelBuilder)
        {
            modelBuilder.ToTable("Poster");
        }
    }

    public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> modelBuilder)
        {
            modelBuilder.ToTable("Achievement");
        }
    }
}
