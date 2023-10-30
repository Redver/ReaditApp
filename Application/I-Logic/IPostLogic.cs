using Domain.DTOs;
using Domain.Models;

namespace Application.I_Logic;

public interface IPostLogic
{
    Task<Post> CreatePostAsync(PostCreateDto postCreateDto);

    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto dto);

    Task UpdatePostAsync(Post post);

    Task<Post> GetPostByIdAsync(int id);

    Task DeletePost(int id);
    
    
}