using Application.I_DAO;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int postid;
        if (context.Posts.Any())
        {
            postid = context.Posts.Max(u => u.Id);
            postid++;
        }
        else
        {
            postid = 1;
        }

        post.Id = postid;

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAllAsync()
    {
        var posts = context.Posts.AsEnumerable();

        return Task.FromResult(posts);
    }
    
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParametersDto)
    {
        IEnumerable < Post > posts = context.Posts.AsEnumerable();
        if (!string.IsNullOrEmpty(searchPostParametersDto.username))
        {
            posts = context.Posts.Where(p =>
                p.Author.Equals(searchPostParametersDto.username, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(searchPostParametersDto.titleContains))
        {
            posts = posts.Where(p =>
                p.Title.Contains(searchPostParametersDto.titleContains, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(searchPostParametersDto.bodyContains))
        {
            posts = posts.Where(p =>
                p.Content.Contains(searchPostParametersDto.bodyContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(posts);
    }  
}