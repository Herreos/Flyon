using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Flyon.Data.SQL.DAO
{
    public class Post
    {
        public Post()
        {
            Rates = new List<Rating>();
            Comments = new List<Comment>();
            Reservations = new List<Reservation>();
        }
        
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CommentsCount { get; set; }
        public int RatesCount { get; set; }
        public double AverangeRate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditionDate { get; set; }
        public string OfferDescription { get; set; }
        public string OfferCountry { get; set; }
        public string OfferCity { get; set; }
        public double OfferCost { get; set; }
        public string OfferPhotoHref { get; set; }
        public string HotelName { get; set; }
        public string DeparturePlace { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public DateTime DateOfReturn { get; set; }
        public bool IsActivePost { get; set; }
        public bool IsBannedPost { get; set; }

        public virtual ICollection<Rating> Rates { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual User User { get; set; }
       
    }
}