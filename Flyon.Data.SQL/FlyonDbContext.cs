using Flyon.Data.SQL.DAO;
using Flyon.Data.SQL.DAOConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Flyon.Data.SQL
{
    public class FlyonDbContext : DbContext
    {
        public FlyonDbContext(DbContextOptions<FlyonDbContext> options) : base(options) { }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<DAO.Post> Post { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<DAO.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new RatingConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}