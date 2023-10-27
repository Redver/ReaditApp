using Domain.DTOs;
using Domain.Models;

namespace BlazorWasm.Services;

public interface IPostService
{
    Task<IEnumerable<Post>> GetAllAsync();

    Task<Post> CreateAsync(PostCreateDto dto);
}