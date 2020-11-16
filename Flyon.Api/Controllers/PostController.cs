using System.Threading.Tasks;
using Flyon.Api.Mappers;
using Flyon.Api.Validation;
using Flyon.Data.SQL;
using Flyon.IServices.Post;
using Microsoft.AspNetCore.Mvc;

namespace Flyon.Api.Controllers
{
    [ApiVersion( "2.0" )]
    [Route( "api/v{version:apiVersion}/post" )]
    public class PostController: Controller
    {
        private readonly FlyonDbContext _context;
        private readonly IPostService _postService;

        public PostController(FlyonDbContext context, IPostService postService)
        {
            _context = context;
            _postService = postService;
        }
        
        [HttpGet("{postId:min(1)}", Name = "GetPostById")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var post = await _postService.GetPost(postId);
            if (post != null)
            {
                return Ok(PostToPostViewModelMapper.PostToPostViewModel(post));
            }
            return NotFound();
        }
        
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] IServices.Requests.CreatePost createPost)
        {
            var post = await _postService.CreatePost(createPost);
            
            return Created(post.PostId.ToString(),PostToPostViewModelMapper.PostToPostViewModel(post)) ;
        }
        
        [ValidateModel]
        [HttpPatch("edit/{postId:min(1)}", Name = "EditPost")]
        public async Task<IActionResult> EditPost([FromBody] IServices.Requests.EditPost editPost, int postId)
        {
            await _postService.EditPost(editPost, postId);
            
            return NoContent();
        }
        
        [HttpDelete("delete/{postId:min(1)}", Name = "DeletePost")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            await _postService.DeletePost(postId);
            return NoContent();
        }
    }
}