using Domain.DTOs;
using Domain.Models;

namespace Application.I_Logic;

public interface IPostLogic
{
    Task<Post> CreatePostAsync(PostCreateDto postCreateDto);

    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto);

    Task<IEnumerable<Post>> UpdatePostAsync(PostUpdateDto dto);
}