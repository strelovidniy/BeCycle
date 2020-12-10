using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackaton_test.Models
{
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
