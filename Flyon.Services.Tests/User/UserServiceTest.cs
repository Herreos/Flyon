using System;
using System.Threading.Tasks;
using Flyon.Common.Enums;
using Flyon.Domain.DomainExceptions;
using Flyon.IData.User;
using Flyon.IServices.Requests;
using Flyon.IServices.User;
using Flyon.Services.User;
using Moq;
using Xunit;

namespace Flyon.Services.Tests.User
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        
        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }
        
        [Fact]
        public void CreateUser_Returns_throws_InvalidBirthDateException()
        {
            var user = new CreateUser
            {
                Email = "Email",
                UserName = "Name",
                Gender = Gender.Male,
                BirthDate = DateTime.UtcNow.AddHours(1),
            };
            
            Assert.ThrowsAsync<InvalidBirthDateException>(() => _userService.CreateUser(user));
        }
        
        [Fact]
        public async Task CreateUser_Returns_Correct_Response()
        {
            var user = new CreateUser
            {
                Email = "Email",
                UserName = "Name",
                Gender = Gender.Male,
                BirthDate = DateTime.UtcNow,
            };
            
            int expectedResult = 0;
            _userRepositoryMock.Setup(x => x.AddUser
                (new Domain.User.User
                (user.UserName, 
                    user.Password,
                    user.Email, 
                    user.Gender, 
                    user.BirthDate)))
                .Returns(Task.FromResult(expectedResult));
            
            var result = await _userService.CreateUser(user);
            
            Assert.IsType<Domain.User.User>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Id);
        }

    }
}