using ApiByVibeCoding.Models;

namespace ApiByVibeCoding.Services;

public interface ICommentService
{
    Task<IEnumerable<Comment>> GetCommentsAsync();
    Task<Comment?> CreateCommentAsync(Comment comment);
    Task<Comment?> UpdateCommentAsync(int id, Comment comment);
    Task<bool> DeleteCommentAsync(int id);
}