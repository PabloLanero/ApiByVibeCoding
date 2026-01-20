using ApiByVibeCoding.Models;

namespace ApiByVibeCoding.Services;

public interface IPostService
{
    Task<IEnumerable<Post>> GetPostsAsync();
    Task<Post?> CreatePostAsync(Post post);
    Task<Post?> UpdatePostAsync(int id, Post post);
    Task<bool> DeletePostAsync(int id);
}