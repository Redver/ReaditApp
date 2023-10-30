using System.Net.Http.Headers;
using System.Text;
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

    public async Task CreateAsync(PostCreateDto dto)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtAuthService.Jwt);
        var postAsJson = JsonSerializer.Serialize(dto);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7130/Post", content);
        
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);
        
    }

    public async Task UpdateAsync(AddCommentToPostDto dto)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtAuthService.Jwt);
        var postAsJson = JsonSerializer.Serialize(dto);
        string id = dto.PostId.ToString();
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        var response = await client.PatchAsync("https://localhost:7130/Post/"+id, content);
        
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);
    }
}