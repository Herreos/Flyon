using System;
using Flyon.Common.Enums;

namespace Flyon.Api.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Gender Gender { get; set; }
        public string CurrentCountry { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentStreetName { get; set; }
        public string CurrentHouseNumber { get; set; }
        public string CurrentFlatNumber { get; set; }
        public string UserRank { get; set; }
        public bool IsBannedUser { get; set; }
        public bool IsActiveUser { get; set; }
        public string IconHref { get; set; }

    }
}