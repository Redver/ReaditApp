using Application.I_DAO;
using Application.I_Logic;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }

    public async Task<Post> CreatePostAsync(PostCreateDto post)
    {
        var toCreate = new Post
        {
            Title = post.Title,
            Author = post.Author,
            Content = post.Content,
            PostDate = DateTime.Now
        };
        var created = await postDao.CreateAsync(toCreate);
        return created;
    }

    public Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return postDao.GetAllAsync();
    }
    
    public   Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParametersDto)
    {
        return postDao.GetAsync(searchPostParametersDto);
    }
    
    
    public   Task<IEnumerable<Post>> UpdatePostAsync(PostUpdateDto postUpdateDto)
    {
        var newComment = new Post()
        {
            Author = postUpdateDto.Commenter,
            Content = postUpdateDto.Comment,
            Id = postUpdateDto.PostId
            // Id is of the post this is attached to
        };
        SearchPostParametersDto dto = new SearchPostParametersDto(null,null,null,postUpdateDto.PostId);
        Task<IEnumerable<Post>> postToUpdate = this.GetAsync(dto);
        
        return postToUpdate;
    }

    public Task<Post> GetPostByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeletePost(int id)
    {
        throw new NotImplementedException();
    }
}