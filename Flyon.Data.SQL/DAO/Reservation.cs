using System;

namespace Flyon.Data.SQL.DAO
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string ReservationNumber { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public bool IsPaid { get; set; }
        
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}