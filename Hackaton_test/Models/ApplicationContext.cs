using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
            builder.DataSource = @"mentor-me-dbserver.database.windows.net,1433";
            builder.UserID = "MentorMeDbUser@mentor-me-dbserver";
            builder.Password = "!Mentor123";
            builder.InitialCatalog = "BeCycle";
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
    }
}
