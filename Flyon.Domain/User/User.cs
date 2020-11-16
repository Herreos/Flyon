using System;
using Flyon.Common.Enums;
using Flyon.Domain.DomainExceptions;

namespace Flyon.Domain.User
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CurrentCountry { get; private set; }
        public string CurrentCity { get; private set; }
        public string CurrentStreetName { get; private set; }
        public string CurrentHouseNumber { get; private set; }
        public string CurrentFlatNumber { get; private set; }
        public DateTime CreationDate { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool IsBannedUser { get; private set; }
        public bool IsActiveUser { get; private set; }
        public string IconHref { get; private set; }
        
        public User(int id, string userName, string email, string firstName, string lastName, DateTime creationDate, Gender gender, DateTime birthDate, string country, string city, string street, string houseNr, string flatNr, bool isBannedUser, bool isActiveUser, string iconHref)
        {
            Id = id;
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            CreationDate = creationDate;
            Gender = gender;
            BirthDate = birthDate;
            CurrentCountry = country;
            CurrentCity = city;
            CurrentStreetName = street;
            CurrentHouseNumber = houseNr;
            CurrentFlatNumber = flatNr;
            IsBannedUser = isBannedUser;
            IsActiveUser = isActiveUser;
            IconHref = iconHref;
        }

        public User(string userName, string email, string password, Gender gender, DateTime birthDate)
        {
            UserName = userName;
            Email = email;
            Password = password;
            Gender = gender;
            BirthDate = birthDate;
            IsBannedUser = false;
            IsActiveUser = true;
        }
        
        public User(string userName, string email, Gender gender, DateTime birthDate)
        {
            if (birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(birthDate);
            UserName = userName;
            Email = email;
            Gender = gender;
            BirthDate = birthDate;
            CreationDate = DateTime.UtcNow;
            IsBannedUser = false;
            IsActiveUser = true;
        }
        
        public void EditUser(string userName, string email, Gender gender, DateTime birthDate)
        {
            if (birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(birthDate);
            UserName = userName;
            Email = email;
            Gender = gender;
            BirthDate = birthDate;
        }

        public User(int userId)
        {
            Id = userId;
        }

    }
}