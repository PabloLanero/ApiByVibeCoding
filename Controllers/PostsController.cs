using Microsoft.AspNetCore.Mvc;
using ApiByVibeCoding.Models;
using ApiByVibeCoding.Services;

namespace ApiByVibeCoding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        try
        {
            var posts = await _postService.GetPostsAsync();
            return Ok(posts);
        }
        catch (HttpRequestException)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
    {
        try
        {
            var createdPost = await _postService.CreatePostAsync(post);
            return Ok(createdPost);
        }
        catch (HttpRequestException)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Post>> UpdatePost(int id, [FromBody] Post post)
    {
        try
        {
            var updatedPost = await _postService.UpdatePostAsync(id, post);
            return Ok(updatedPost);
        }
        catch (HttpRequestException)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        try
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
        catch (HttpRequestException)
        {
            return StatusCode(500);
        }
    }
}