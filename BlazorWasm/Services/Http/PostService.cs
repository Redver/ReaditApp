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
        HttpResponseMessage response = await client.GetAsync("https://localhost:7130/Post");
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);

        IEnumerable<Post>? posts = JsonSerializer.Deserialize<IEnumerable<Post>>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return posts!;
    }

    public async Task CreateAsync(PostCreateDto dto)
    {
        var postAsJson = JsonSerializer.Serialize(dto);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7130/Post", content);
        
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);
        
    }
/*
    public async Task UpdateAsync(PostUpdateDto updateDto)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtAuthService.Jwt);
        var postAsJson = JsonSerializer.Serialize(updateDto);
        string id = updateDto.PostId.ToString();
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        var response = await client.PatchAsync("https://localhost:7130/Post/"+id, content);
        
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);
    }
    */
    public async Task UpdateAsync(PostUpdateDto dto)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtAuthService.Jwt);
        int? id = dto.PostId;
        id--;
        string stringId = id.ToString();
        string dtoAsJson = JsonSerializer.Serialize(dto);
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PatchAsync("https://localhost:7130/post/"+stringId, body);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }

    }
}