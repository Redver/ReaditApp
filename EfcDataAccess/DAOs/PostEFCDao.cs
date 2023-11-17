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
        IQueryable<Post> query = context.Posts.Include(post => post.Author).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParameters.username))
        {
            // we know username is unique, so just fetch the first
            query = query.Where(post =>
                post.Author.UserName.ToLower().Equals(searchParameters.username.ToLower()));
        }
    
        if (searchParameters.id != null)
        {
            query = query.Where(t => t.Author.Id == searchParameters.id);
        }
        
        if (!string.IsNullOrEmpty(searchParameters.titleContains))
        {
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchParameters.titleContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }
    
    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }
}