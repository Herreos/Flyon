using System.Threading.Tasks;

namespace Flyon.IData.Post
{
    public interface IPostRepository
    {
        Task<int> AddPost(Flyon.Domain.Post.Post post);
        Task<Flyon.Domain.Post.Post> GetPost(int postId);
        Task EditPost(Domain.Post.Post post);
        Task<Flyon.Domain.Post.Post> DeletePost(int postId);
    }
}