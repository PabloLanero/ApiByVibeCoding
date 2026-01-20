using ApiByVibeCoding.Models;
using ApiByVibeCoding.Repositories;

namespace ApiByVibeCoding.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<Comment>> GetCommentsAsync()
    {
        return await _commentRepository.GetAllAsync();
    }

    public async Task<Comment?> CreateCommentAsync(Comment comment)
    {
        return await _commentRepository.CreateAsync(comment);
    }

    public async Task<Comment?> UpdateCommentAsync(int id, Comment comment)
    {
        return await _commentRepository.UpdateAsync(id, comment);
    }

    public async Task<bool> DeleteCommentAsync(int id)
    {
        return await _commentRepository.DeleteAsync(id);
    }
}