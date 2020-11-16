using Flyon.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flyon.Data.SQL.DAOConfiguration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(c => c.IsPaid).HasColumnType("tinyint(1)");
            
            builder.HasOne(x => x.User)
                .WithMany(x => x.Reservations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Reservations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PostId);
        }
    }
}