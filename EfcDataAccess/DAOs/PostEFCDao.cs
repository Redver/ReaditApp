using Application.I_DAO;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEFCDao : IPostDao
{
    private readonly ReaditContext context;

    public PostEFCDao(ReaditContext context)
    {
        this.context = context;
    }
    
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }
    public Task<IEnumerable<Post>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IQueryable<Post> postsQuery = context.Posts.AsQueryable();
        if (searchParameters.titleContains != null)
        {
            postsQuery = postsQuery.Where(p => p.Title.ToLower().Contains(searchParameters.titleContains.ToLower()));
        }

        IEnumerable<Post> result = await postsQuery.ToListAsync();
        return result;
    }

    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }
}