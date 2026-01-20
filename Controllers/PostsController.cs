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
}