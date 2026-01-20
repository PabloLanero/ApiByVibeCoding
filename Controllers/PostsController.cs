using Microsoft.AspNetCore.Mvc;
using ApiByVibeCoding.Models;
using System.Text.Json;

namespace ApiByVibeCoding.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public PostsController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
        var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
        
        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode);

        var json = await response.Content.ReadAsStringAsync();
        var posts = JsonSerializer.Deserialize<List<Post>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return Ok(posts);
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
    {
        var json = JsonSerializer.Serialize(post);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PostAsync("https://jsonplaceholder.typicode.com/posts", content);
        
        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode);

        var responseJson = await response.Content.ReadAsStringAsync();
        var createdPost = JsonSerializer.Deserialize<Post>(responseJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return Ok(createdPost);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Post>> UpdatePost(int id, [FromBody] Post post)
    {
        post.Id = id;
        var json = JsonSerializer.Serialize(post);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        
        var response = await _httpClient.PutAsync($"https://jsonplaceholder.typicode.com/posts/{id}", content);
        
        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode);

        var responseJson = await response.Content.ReadAsStringAsync();
        var updatedPost = JsonSerializer.Deserialize<Post>(responseJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return Ok(updatedPost);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        var response = await _httpClient.DeleteAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
        
        if (!response.IsSuccessStatusCode)
            return StatusCode((int)response.StatusCode);

        return NoContent();
    }
}