using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackaton_test.Models
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("User").HasAlternateKey(u => u.NickName);
            modelBuilder.HasAlternateKey(u => u.Email);
            modelBuilder.Property(n => n.NickName).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.City).HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.FirstName).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.LastName).HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.Email).IsRequired().HasColumnType("nvarchar(50)");
            modelBuilder.Property(u => u.PhoneNumber).HasColumnType("nvarchar(15)");
            modelBuilder.Property(u => u.ImageURL).HasColumnType("nvarchar(500)");

            modelBuilder.HasMany(p => p.EventFollowers)
                .WithOne(ef => ef.Follower)
                .HasForeignKey(f => f.FollowerId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.HasMany(u => u.UserFriends)
                .WithOne(f => f.Friend)
                .HasForeignKey(f => f.FriendId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
