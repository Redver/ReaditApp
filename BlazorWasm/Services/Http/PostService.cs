using System.Net.Http.Headers;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;

namespace BlazorWasm.Services.Http;

public class PostService : IPostService
{
    private readonly HttpClient client;

    public PostService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtAuthService.Jwt);
        var response = await client.GetAsync("https://localhost:7130/Post");
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);

        var posts = JsonSerializer.Deserialize<IEnumerable<Post>>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return posts!;
    }

    public Task<Post> CreateAsync(PostCreateDto dto)
    {
        throw new NotImplementedException();
    }
}