using System.Threading.Tasks;
using Flyon.IData.User;
using Microsoft.EntityFrameworkCore;

namespace Flyon.Data.SQL.User
{
    public class UserRepository: IUserRepository
    {
        private readonly FlyonDbContext _context;

        public UserRepository(FlyonDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUser(Domain.User.User user)
        {
            var userDAO =  new DAO.User { 
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                RegistrationDate = user.CreationDate,
                IsActiveUser = user.IsActiveUser,
                IsBannedUser = user.IsBannedUser,
            };
            await _context.AddAsync(userDAO);
            await _context.SaveChangesAsync();
            return userDAO.UserId;
        }

        public async Task<Domain.User.User> GetUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);

            if (user != null)
            {
                return new Domain.User.User(user.UserId,
                    user.UserName,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.RegistrationDate,
                    user.Gender,
                    user.BirthDate,
                    user.CurrentCountry,
                    user.CurrentCity,
                    user.CurrentStreetName,
                    user.CurrentHouseNumber,
                    user.CurrentFlatNumber,
                    user.IsBannedUser,
                    user.IsActiveUser,
                    user.IconHref);
            }
            return null;
        }

        public async Task<Domain.User.User> GetUser(string userName)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=>x.UserName == userName);

            if (user != null)
            {
                return new Domain.User.User(user.UserId,
                    user.UserName,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.RegistrationDate,
                    user.Gender,
                    user.BirthDate,
                    user.CurrentCountry,
                    user.CurrentCity,
                    user.CurrentStreetName,
                    user.CurrentHouseNumber,
                    user.CurrentFlatNumber,
                    user.IsBannedUser,
                    user.IsActiveUser,
                    user.IconHref);
            }
            return null;
        }

        public async Task EditUser(Domain.User.User user)
        {
            var editUser = await _context.User.FirstOrDefaultAsync(x=>x.UserId == user.Id);
            editUser.UserName = user.UserName;
            editUser.Email = user.Email;
            editUser.Gender = user.Gender;
            editUser.BirthDate = user.BirthDate;
            await _context.SaveChangesAsync();
        }
        
        public async Task<Domain.User.User> DeleteUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=>x.UserId == userId);
            _context.User.Remove(user);
            _context.SaveChanges();
            return new Domain.User.User(userId);
        }
    }

}