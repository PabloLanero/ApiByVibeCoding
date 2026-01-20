using ApiByVibeCoding.Models;
using ApiByVibeCoding.Repositories;

namespace ApiByVibeCoding.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<Post>> GetPostsAsync()
    {
        return await _postRepository.GetAllAsync();
    }

    public async Task<Post?> CreatePostAsync(Post post)
    {
        return await _postRepository.CreateAsync(post);
    }

    public async Task<Post?> UpdatePostAsync(int id, Post post)
    {
        return await _postRepository.UpdateAsync(id, post);
    }

    public async Task<bool> DeletePostAsync(int id)
    {
        return await _postRepository.DeleteAsync(id);
    }
}