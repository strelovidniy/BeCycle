using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackaton_test.Models
{
    public class PosterConfiguration : IEntityTypeConfiguration<Poster>
    {
        public void Configure(EntityTypeBuilder<Poster> modelBuilder)
        {
            modelBuilder.ToTable("Poster");
            modelBuilder.Property(p => p.PublicationDate).HasColumnType("date");
            modelBuilder.Property(p => p.EventDate).HasColumnType("date");
            modelBuilder.Property(p => p.Title).HasColumnType("nvarchar(100)");
            modelBuilder.Property(p => p.Description).HasColumnType("nvarchar(500)");
            modelBuilder.HasOne(p => p.Author)
                .WithMany(u => u.Posters)
                .HasForeignKey(p => p.AuthorId);
            modelBuilder.HasMany(p => p.EventFollowers)
                .WithOne(ef => ef.Event)
                .HasForeignKey(f => f.EventId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
