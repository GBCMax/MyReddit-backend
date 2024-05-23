using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyReddit.API.Contracts;
using MyReddit.API.Contracts.Posts;
using MyReddit.Core.Interfaces.Services;
using MyReddit.Core.Models;

namespace MyReddit.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAllPosts")]
        public async Task<ActionResult<List<PostsResponse>>> GetPosts()
        {
            var posts = await _postService.GetAllPosts();

            var postsResponse = posts.Select(x => new PostsResponse(x.Id, x.Title, x.Content));

            return Ok(postsResponse);
        }

        [HttpGet("GetPostByTitle")]
        public async Task<ActionResult<List<PostsResponse>>> GetPostByTitle([FromQuery] string title)
        {
            var posts = await _postService.GetPostByTitle(title);

            if(posts == null)
            {
                return BadRequest("Не найдено!");
            }

            var postsResponse = posts.Select(x => new PostsResponse(x.Id, x.Title, x.Content));

            return Ok(postsResponse);
        }

        [HttpGet("GetPostByUser")]
        public async Task<ActionResult<List<PostsResponse>>> GetPostByUser([FromQuery] Guid userId)
        {
            var posts = await _postService.GetPostByUser(userId);

            if (posts == null)
            {
                return BadRequest("Не найдено!");
            }

            var postsResponse = posts.Select(x => new PostsResponse(x.Id, x.Title, x.Content));

            return Ok(postsResponse);
        }

        [HttpGet("GetPostByTopic")]
        public async Task<ActionResult<List<PostsResponse>>> GetPostByTopic([FromQuery] Guid topicId)
        {
            var posts = await _postService.GetPostByTopic(topicId);

            if (posts == null)
            {
                return BadRequest("Не найдено!");
            }

            var postsResponse = posts.Select(x => new PostsResponse(x.Id, x.Title, x.Content));

            return Ok(postsResponse);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePost([FromBody] PostsRequest request)
        {
            var (post, error) = Post.Create(
                Guid.NewGuid(),
                request.Title,
                request.Content);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var postsRequest = await _postService.CreatePost(post, request.UserId, request.TopicId);

            return Ok(postsRequest);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdatePost(Guid id, [FromBody] PostsRequest request)
        {
            var postId = await _postService.UpdatePost(id, request.Title, request.Content);

            return Ok(postId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeletePost(Guid id)
        {
            return Ok(await _postService.DeletePost(id));
        }
    }
}
