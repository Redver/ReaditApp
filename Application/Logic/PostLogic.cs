using Application.I_DAO;
using Application.I_Logic;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic: IPostLogic
{
    
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }

    public async Task<Post> CreatePostAsync(PostCreateDto post)
    {
        Post toCreate = new Post()
        {
            Title = post.Title,
            Author = post.Author,
            Content = post.Content,
            PostDate =  DateTime.Now   
        };
        Post created = await postDao.CreateAsync(toCreate);
        return created;
    }
    
    public Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return postDao.GetAllAsync();
    }

    public Task UpdatePostAsync(Post post)
    {
        throw new NotImplementedException();
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