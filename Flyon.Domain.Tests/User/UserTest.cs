using System;
using Flyon.Common.Enums;
using Flyon.Domain.DomainExceptions;
using Xunit;

namespace Flyon.Domain.Tests.User
{
    public class UserTest
    {
        public UserTest()
        {
        }

        [Fact]
        public void CreateUser_Returns_throws_InvalidBirthDateException()
        {
            Assert.Throws<InvalidBirthDateException>
            (() => new Domain.User.User("Name",
                "Email",
                Gender.Male,
                DateTime.UtcNow.AddHours(1)));
        }
        
        [Fact]
        public void CreateUser_Returns_Correct_Response()
        {
            var user = new Domain.User.User("Name", "Email@mail.com", Gender.Male, DateTime.UtcNow);

            Assert.Equal(Gender.Male, user.Gender);
            Assert.Equal("Email@mail.com", user.Email);
            Assert.Equal("Name", user.UserName);
        }

    }
}