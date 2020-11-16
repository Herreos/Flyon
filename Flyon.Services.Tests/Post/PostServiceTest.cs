using System;
using System.Threading.Tasks;
using Flyon.Common.Enums;
using Flyon.Domain.DomainExceptions;
using Flyon.IData.Post;
using Flyon.IServices.Requests;
using Flyon.IServices.Post;
using Flyon.Services.Post;
using Moq;
using Xunit;

namespace Flyon.Services.Tests.Post
{
    public class PostServiceTest
    {
        private readonly IPostService _postService;
        private readonly Mock<IPostRepository> _postRepositoryMock;
        
        public PostServiceTest()
        {
            //Arrange
            _postRepositoryMock = new Mock<IPostRepository>();
            _postService = new PostService(_postRepositoryMock.Object);
        }
        
        [Fact]
        public void CreatePost_Returns_throws_InvalidOfferCityException()
        {
            var post = new CreatePost
            {
                UserId = 1,
                OfferCountry = "Polska",
                OfferCity = null,
                OfferDescription = "Opis oferty",
                OfferPhotoHref = "img/obrazek.jpg"
            };

            Assert.ThrowsAsync<InvalidOfferCityException>(() => _postService.CreatePost(post));
        }
        
        [Fact]
        public async Task CreatePost_Returns_Correct_Response()
        {
            var post = new CreatePost
            {
                UserId = 1,
                OfferCountry = "Polska",
                OfferCity = "Bydgoszcz",
                OfferCost = 2500.00,
                OfferDescription = "Opis oferty",
                OfferPhotoHref = "img/obrazek.jpg"
            };
            
            int expectedResult = 0;
            _postRepositoryMock.Setup(x => x.AddPost
                (new Domain.Post.Post
                (post.UserId, 
                    post.OfferCountry, 
                    post.OfferCity, 
                    post.OfferCost,
                    post.OfferDescription,
                    post.OfferPhotoHref)))
                .Returns(Task.FromResult(expectedResult));
            
            //Act
            var result = await _postService.CreatePost(post);

            //Assert
            Assert.IsType<Domain.Post.Post>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.PostId);
        }

    }
}