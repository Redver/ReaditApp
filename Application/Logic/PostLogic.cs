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
        var toCreate = new Post(post.Title, post.Author.Id, post.Content, DateTime.Now);
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
    
    
    public   async Task UpdatePostAsync(PostUpdateDto postUpdateDto)
    {
        
        SearchPostParametersDto postSearchParameter = new SearchPostParametersDto(null,null,null,postUpdateDto.PostId);

        IEnumerable<Post> toUpdate = await postDao.GetAsync(postSearchParameter);
        
       // Post newComment = new Post(postUpdateDto.PostId, null, postUpdateDto.Commenter, postUpdateDto.Comment);

        Post postToUpdate = toUpdate.First();
        
       // postToUpdate.Comments.Add(newComment);
        
        await postDao.UpdateAsync(postToUpdate);
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