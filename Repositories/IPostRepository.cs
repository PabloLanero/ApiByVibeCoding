using ApiByVibeCoding.Models;

namespace ApiByVibeCoding.Repositories;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post?> CreateAsync(Post post);
    Task<Post?> UpdateAsync(int id, Post post);
    Task<bool> DeleteAsync(int id);
}