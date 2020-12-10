using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackaton_test.Models
{
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
}
