using System.Threading.Tasks;
using Flyon.IData.User;
using Flyon.IServices.Requests;
using Flyon.IServices.User;

namespace Flyon.Services.User
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Domain.User.User> GetUserByUserId(int userId)
        {
            return _userRepository.GetUser(userId);
        }

        public Task<Domain.User.User> GetUserByUserName(string userName)
        {
            return _userRepository.GetUser(userName);
        }

        public async Task<Domain.User.User> CreateUser(CreateUser createUser)
        {
            var user = new Domain.User.User(createUser.UserName, createUser.Email, createUser.Password, createUser.Gender, createUser.BirthDate);
            user.Id = await _userRepository.AddUser(user);
            return user;
        }

        public async Task EditUser(EditUser createUser, int userId)
        {
            var user = await _userRepository.GetUser(userId);
            user.EditUser(createUser.UserName, createUser.Email, createUser.Gender, createUser.BirthDate);
            await _userRepository.EditUser(user);
        }
        
        public Task<Domain.User.User> DeleteUser(int userId)
        {
            return _userRepository.DeleteUser(userId);
        }
    }

}