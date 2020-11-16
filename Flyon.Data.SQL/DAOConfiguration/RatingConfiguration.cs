using Flyon.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flyon.Data.SQL.DAOConfiguration
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(c => c.RatingDate).IsRequired();
            builder.Property(c => c.Rate).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Rates)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Rates)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PostId);

            builder.ToTable("Rating");
        }
    }
}