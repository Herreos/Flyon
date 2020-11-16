using System;

namespace Flyon.Data.SQL.DAO
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime RatingDate { get; set; }
        public double Rate { get; set; }
        
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}