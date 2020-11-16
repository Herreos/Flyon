using System.Threading.Tasks;
using Flyon.IData.Post;
using Flyon.IServices.Requests;
using Flyon.IServices.Post;

namespace Flyon.Services.Post
{
    public class PostService: IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        public Task<Domain.Post.Post> GetPost(int postId)
        {
            return _postRepository.GetPost(postId);
        }
        
        public async Task<Domain.Post.Post> CreatePost(CreatePost createPost)
        {
            var post = new Domain.Post.Post(createPost.UserId, createPost.CreationDate, createPost.OfferDescription, createPost.OfferCountry, createPost.OfferCity, createPost.OfferCost, createPost.HotelName, createPost.DeparturePlace, createPost.DateOfDeparture, createPost.DateOfReturn, createPost.IsActivePost, createPost.IsBannedPost, createPost.OfferPhotoHref);
            post.PostId = await _postRepository.AddPost(post);
            return post;
        }

        public async Task EditPost(EditPost createPost, int postId)
        {
            var post = await _postRepository.GetPost(postId);
            post.EditPost(createPost.OfferDescription, createPost.OfferCountry, createPost.OfferCity, createPost.OfferCost, createPost.HotelName, createPost.DeparturePlace, createPost.DateOfDeparture, createPost.DateOfReturn, createPost.IsActivePost, createPost.IsBannedPost, createPost.OfferPhotoHref);
            await _postRepository.EditPost(post);
        }

        public Task<Domain.Post.Post> DeletePost(int postId)
        {
            return _postRepository.DeletePost(postId);
        }
    }
}