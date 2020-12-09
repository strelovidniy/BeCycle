using Microsoft.Data.SqlClient;
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
            modelBuilder.Entity<EventFollower>().HasKey(ef => new {ef.EventId, ef.FollowerId});
            modelBuilder.Entity<UserAchievement>().HasKey(ua => new {ua.AchievementId, ua.UserId});
            modelBuilder.Entity<UserFriend>().HasKey(uf => new {uf.FriendId, uf.UserId});
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"hackatondbdbserver.database.windows.net";
            builder.UserID = "HackatonTeam";
            builder.Password = "Hackaton!TopTeam";
            builder.InitialCatalog = "HackatonDB";
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
           
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("User").HasAlternateKey(u => u.NickName);
            modelBuilder.Property(n => n.NickName).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.City).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.FirstName).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.LastName).HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.Email).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.PhoneNumber).HasColumnType("nvarchar(15)");

            modelBuilder.HasMany(p => p.EventFollowers)
                .WithOne(ef => ef.Follower)
                .HasForeignKey(f => f.FollowerId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.HasMany(u => u.UserFriends)
                .WithOne(f => f.Friend)
                .HasForeignKey(f => f.FriendId).OnDelete(DeleteBehavior.NoAction);
        }
    }
    
    public class PosterConfiguration : IEntityTypeConfiguration<Poster>
    {
        public void Configure(EntityTypeBuilder<Poster> modelBuilder)
        {
            modelBuilder.ToTable("Poster");
            modelBuilder.HasOne(p => p.Author)
                .WithMany(u => u.Posters)
                .HasForeignKey(p => p.AuthorId);
            modelBuilder.HasMany(p => p.EventFollowers)
                .WithOne(ef => ef.Event)
                .HasForeignKey(f => f.EventId).OnDelete(DeleteBehavior.NoAction);
        }
    }

    public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> modelBuilder)
        {
            modelBuilder.ToTable("Achievement");
            modelBuilder.Property(a => a.Name).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(a => a.Description).IsRequired().HasColumnType("nvarchar(250)");
        }
    }
}
