using System.Threading.Tasks;

namespace Flyon.IData.User
{
    public interface IUserRepository
    {
        Task<int> AddUser(Flyon.Domain.User.User user);
        Task<Flyon.Domain.User.User> GetUser(int userId);
        Task<Flyon.Domain.User.User> GetUser(string userName);
        Task EditUser(Domain.User.User user);
        Task<Flyon.Domain.User.User> DeleteUser(int userId);
    }
}