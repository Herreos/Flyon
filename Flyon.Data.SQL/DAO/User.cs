using System;
using System.Collections.Generic;
using Flyon.Common.Enums;

namespace Flyon.Data.SQL.DAO
{
    public class User
    {
        
        public User()
        {
            Reservations = new List<Reservation>();
            Posts = new List<Post>();
            Rates = new List<Rating>();
            Comments = new List<Comment>();
        }
        
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string CurrentCountry { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentStreetName { get; set; }
        public string CurrentHouseNumber { get; set; }
        public string CurrentFlatNumber { get; set; }
        public string UserRank { get; set; }
        public bool IsActiveUser { get; set; }
        public bool IsBannedUser { get; set; }
        public string IconHref { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Rating> Rates { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}