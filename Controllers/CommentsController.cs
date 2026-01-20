using Microsoft.AspNetCore.Mvc;
using ApiByVibeCoding.Models;
using ApiByVibeCoding.Services;

namespace ApiByVibeCoding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
    {
        try
        {
            var comments = await _commentService.GetCommentsAsync();
            return Ok(comments);
        }
        catch (HttpRequestException)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> CreateComment([FromBody] Comment comment)
    {
        try
        {
            var createdComment = await _commentService.CreateCommentAsync(comment);
            return Ok(createdComment);
        }
        catch (HttpRequestException)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Comment>> UpdateComment(int id, [FromBody] Comment comment)
    {
        try
        {
            var updatedComment = await _commentService.UpdateCommentAsync(id, comment);
            return Ok(updatedComment);
        }
        catch (HttpRequestException)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteComment(int id)
    {
        try
        {
            await _commentService.DeleteCommentAsync(id);
            return NoContent();
        }
        catch (HttpRequestException)
        {
            return StatusCode(500);
        }
    }
}