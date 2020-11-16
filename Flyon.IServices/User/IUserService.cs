using System.Threading.Tasks;
using Flyon.IServices.Requests;

namespace Flyon.IServices.User
{
    public interface IUserService
    {
        Task<Flyon.Domain.User.User> GetUserByUserId(int userId);
        Task<Flyon.Domain.User.User> GetUserByUserName(string userName);
        Task<Flyon.Domain.User.User> CreateUser(CreateUser createUser);
        Task EditUser(EditUser createUser, int userId);
        Task<Flyon.Domain.User.User> DeleteUser(int userId);
    }
}