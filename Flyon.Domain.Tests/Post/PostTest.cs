using System;
using Flyon.Common.Enums;
using Flyon.Domain.DomainExceptions;
using Xunit;

namespace Flyon.Domain.Tests.Post
{
    public class PostTest
    {
        public PostTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void CreatePost_Returns_throws_InvalidOfferCityException()
        {
            Assert.Throws<InvalidOfferCityException>
            (() => new Domain.Post.Post(1,
                "Polska",
                null,
                2500.00,
                "Bardzo fajna wycieczka na Mazurach!",
                "img/offerMazury.jpg"));
        }
        
        [Fact]
        public void CreatePost_Returns_Correct_Response()
        {
            var post = new Domain.Post.Post(1, "Polska", "Mazury", 2500.00, "Bardzo fajna wycieczka na Mazurach!", "img/offerMazury.jpg");

            Assert.Equal(1, post.UserId);
            Assert.Equal("Polska", post.OfferCountry);
            Assert.Equal("Mazury", post.OfferCity);
            Assert.Equal(2500.00, post.OfferCost);
            Assert.Equal("Bardzo fajna wycieczka na Mazurach!", post.OfferDescription);
            Assert.Equal("img/offerMazury.jpg", post.OfferPhotoHref);
        }

    }
}