using System;
using Flyon.Domain.DomainExceptions;

namespace Flyon.Domain.Post
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditionDate { get; set; }
        public string OfferDescription { get; set; }
        public string OfferCountry { get; set; }
        public string OfferCity { get; set; }
        public double OfferCost { get; set; }
        public string HotelName { get; set; }
        public string DeparturePlace { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public DateTime DateOfReturn { get; set; }
        public bool IsActivePost { get; set; }
        public bool IsBannedPost { get; set; }
        public string OfferPhotoHref { get; set; }
        
        public Post(int postId, int userId, DateTime creationDate, DateTime editionDate, string description, string country, string city, double cost, string hotel, string departure, DateTime departureDate, DateTime returnDate, bool isActivePost, bool isBannedPost)
        {
            PostId = postId;
            UserId = userId;
            CreationDate = creationDate;
            EditionDate = editionDate;
            OfferDescription = description;
            OfferCountry = country;
            OfferCity = city;
            OfferCost = cost;
            HotelName = hotel;
            DeparturePlace = departure;
            DateOfDeparture = departureDate;
            DateOfReturn = returnDate;
            IsActivePost = isActivePost;
            IsBannedPost = isBannedPost;
        }

        public Post(int userId, DateTime creationDate, string description, string country, string city, double cost, string hotel, string departure, DateTime departureDate, DateTime returnDate, bool isActivePost, bool isBannedPost, string offerPhoto)
        {
            UserId = userId;
            CreationDate = creationDate;
            OfferDescription = description;
            OfferCountry = country;
            OfferCity = city;
            OfferCost = cost;
            HotelName = hotel;
            DeparturePlace = departure;
            DateOfDeparture = departureDate;
            DateOfReturn = returnDate;
            IsActivePost = isActivePost;
            IsBannedPost = isBannedPost;
            OfferPhotoHref = offerPhoto;
        }

        public Post(int userId, string country, string city, double cost, string description, string offerImg)
        {
            UserId = userId;
            OfferCountry = country;
            OfferCity = city;
            OfferCost = cost;
            OfferDescription = description;
            OfferPhotoHref = offerImg;
            if(OfferCity == null)
                throw new InvalidOfferCityException();
        }
        
        public Post(string country, string city, double cost, string description, string offerImg)
        {
            OfferCountry = country;
            OfferCity = city;
            OfferCost = cost;
            OfferDescription = description;
            OfferPhotoHref = offerImg;
            if(OfferCity == null)
                throw new InvalidOfferCityException();
        }
        
        public void EditPost(string description, string country, string city, double cost, string hotel, string departure, DateTime departureDate, DateTime returnDate, bool isActivePost, bool isBannedPost, string offerPhoto)
        {
            OfferDescription = description;
            OfferCountry = country;
            OfferCity = city;
            OfferCost = cost;
            HotelName = hotel;
            DeparturePlace = departure;
            DateOfDeparture = departureDate;
            DateOfReturn = returnDate;
            IsActivePost = isActivePost;
            IsBannedPost = isBannedPost;
            OfferPhotoHref = offerPhoto;
        }
        
        public Post(int postId)
        {
            PostId = postId;
        }
    }
}