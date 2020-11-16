using Flyon.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flyon.Data.SQL.DAOConfiguration
{
    public class PostConfiguration : IEntityTypeConfiguration<DAO.Post>
    {
        public void Configure(EntityTypeBuilder<DAO.Post> builder)
        {
            builder.Property(c => c.OfferCity).IsRequired();
            builder.Property(c => c.OfferCost).IsRequired();
            builder.Property(c => c.OfferCountry).IsRequired();
            builder.Property(c => c.OfferDescription).IsRequired();
            builder.Property(c => c.OfferPhotoHref).IsRequired();
            
            builder.Property(c => c.IsBannedPost).HasColumnType("tinyint(1)");
            builder.Property(c => c.IsActivePost).HasColumnType("tinyint(1)");
            
            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);

            builder.ToTable("Post");

        }
    }
}