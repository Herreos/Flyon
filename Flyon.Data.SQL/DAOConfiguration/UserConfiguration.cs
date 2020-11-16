using Flyon.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flyon.Data.SQL.DAOConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<DAO.User>
    {
        public void Configure(EntityTypeBuilder<DAO.User> builder)
        {
            builder.Property(c => c.UserName).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.IsActiveUser).HasColumnType("tinyint(1)");
            builder.Property(c => c.IsBannedUser).HasColumnType("tinyint(1)");
            builder.ToTable("User");
        }
    }
}