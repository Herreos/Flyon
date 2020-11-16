using System.Threading.Tasks;
using Flyon.IServices.Requests;

namespace Flyon.IServices.Post
{
    public interface IPostService
    {
        Task<Flyon.Domain.Post.Post> GetPost(int postId);
        Task<Flyon.Domain.Post.Post> CreatePost(CreatePost createPost);
        Task EditPost(EditPost createPost, int postId);
        Task<Flyon.Domain.Post.Post> DeletePost(int postId);
    }
}