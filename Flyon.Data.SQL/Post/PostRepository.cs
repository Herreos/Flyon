using System.Threading.Tasks;
using Flyon.IData.Post;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;


namespace Flyon.Data.SQL.Post
{
    public class PostRepository : IPostRepository
    {
        private readonly FlyonDbContext _context;

        public PostRepository(FlyonDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> AddPost(Domain.Post.Post post)
        {
            var postDAO =  new DAO.Post {
                UserId = post.UserId,
                CreationDate = post.CreationDate,
                OfferCountry = post.OfferCountry,
                OfferCity = post.OfferCity,
                OfferDescription = post.OfferDescription,
                OfferCost = post.OfferCost,
                HotelName = post.HotelName,
                DeparturePlace = post.DeparturePlace,
                DateOfDeparture = post.DateOfDeparture,
                DateOfReturn = post.DateOfReturn,
                IsActivePost = post.IsActivePost,
                IsBannedPost = post.IsBannedPost,
                OfferPhotoHref = post.OfferPhotoHref
            };
            await _context.AddAsync(postDAO);
            await _context.SaveChangesAsync();
            return postDAO.PostId;
        }
        
        
        public async Task<Domain.Post.Post> GetPost(int postId)
        {
            var post = await _context.Post.FirstOrDefaultAsync(x=>x.PostId == postId);
            return new Domain.Post.Post(post.PostId,
                post.UserId,
                post.CreationDate,
                post.EditionDate,
                post.OfferDescription,
                post.OfferCountry,
                post.OfferCity,
                post.OfferCost,
                post.HotelName,
                post.DeparturePlace,
                post.DateOfDeparture,
                post.DateOfReturn,
                post.IsActivePost,
                post.IsBannedPost);
        }

        public async Task EditPost(Domain.Post.Post post)
        {
            var editPost = await _context.Post.FirstOrDefaultAsync(x => x.PostId == post.PostId);
            editPost.OfferCountry = post.OfferCountry;
            editPost.OfferCity = post.OfferCity;
            editPost.OfferCost = post.OfferCost;
            editPost.OfferDescription = post.OfferDescription;
            editPost.HotelName = post.HotelName;
            editPost.DeparturePlace = post.DeparturePlace;
            editPost.DateOfDeparture = post.DateOfDeparture;
            editPost.DateOfReturn = post.DateOfReturn;
            editPost.IsActivePost = post.IsActivePost;
            editPost.IsBannedPost = post.IsBannedPost;
            editPost.OfferPhotoHref = post.OfferPhotoHref;
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Post.Post> DeletePost(int postId)
        {
            var post = await _context.Post.FirstOrDefaultAsync(x=>x.PostId == postId);
            _context.Post.Remove(post);
            _context.SaveChanges();
            return new Domain.Post.Post(postId);
        }
    }
}