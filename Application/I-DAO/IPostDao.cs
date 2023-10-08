using Domain.Models;

namespace Application.I_DAO;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    
    Task<IEnumerable<Post>> GetAllAsync();
}