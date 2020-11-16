using System;

namespace Flyon.Api.ViewModels
{
    public class PostViewModel
    {
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
    }
}