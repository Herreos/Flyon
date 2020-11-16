using Flyon.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flyon.Data.SQL.DAOConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.CommentBody).IsRequired();

            builder.Property(c => c.IsActiveComment).HasColumnType("tinyint(1)");
            builder.Property(c => c.IsBannedComment).HasColumnType("tinyint(1)");

            builder.HasOne(x => x.ParentComment)
                .WithMany(x => x.SubComments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.ParentCommentId);
            
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PostId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);

            builder.ToTable("Comment");
        }
    }
}