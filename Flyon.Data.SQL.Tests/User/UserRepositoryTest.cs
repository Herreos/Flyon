using System;
using System.Threading.Tasks;
using Flyon.Common.Enums;
using Flyon.Data.SQL.User;
using Flyon.IData.User;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Flyon.Data.SQL.Tests.User
{
    public class UserRepositoryTest
    {
        private  FlyonDbContext _context;
        private  IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FlyonDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=root;pwd=root;port=3306;database=flyon_db;");
            _context = new FlyonDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _userRepository = new UserRepository(_context);
        }
        
        [Fact]
        public async Task AddUser_Returns_Correct_Response()
        {
            var user = new Domain.User.User("Name", "Email", "mySecretPassword", Gender.Male, DateTime.UtcNow);
            
            var userId = await _userRepository.AddUser(user);
            
            var createdUser = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            Assert.NotNull(createdUser);

            _context.User.Remove(createdUser);
            await _context.SaveChangesAsync();
        }

    }
}