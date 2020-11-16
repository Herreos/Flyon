using System;
using System.Threading.Tasks;
using Flyon.Data.SQL.Post;
using Flyon.IData.Post;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Flyon.Data.SQL.Tests.Post
{
    public class PostRepositoryTest
    {
        //public IConfiguration Configuration { get; }
        private  FlyonDbContext _context;
        private  IPostRepository _postRepository;

        public PostRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FlyonDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=root;pwd=root;port=3306;database=flyon_db;");
            _context = new FlyonDbContext(optionsBuilder.Options);
            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _postRepository = new PostRepository(_context);
        }
        
        [Fact]
        public async Task AddPost_Returns_Correct_Response()
        {
            var post = new Domain.Post.Post(1, "Polska", "Mazury", 2500.00, "Bardzo fajna wycieczka na Mazurach!", "img/offerMazury.jpg");
            
            var postId = await _postRepository.AddPost(post);
            
            var createdPost = await _context.Post.FirstOrDefaultAsync(x => x.PostId == postId);
            Assert.NotNull(createdPost);

            _context.Post.Remove(createdPost);
            await _context.SaveChangesAsync();
        }

    }
}