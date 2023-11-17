
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
    public Post(int id, string? title, User author, string content, DateTime postDate, List<Post>? comments)
    {
        Id = id;
        Title = title;
        Author = author;
        Content = content;
        PostDate = postDate;
        Comments = comments;
    }
    
    public Post(int id, string? title, User author, string content)
    {
        Title = title;
        AuthorId = authorId;
        Content = content;
        PostDate = postDate;
    }
    
    public Post(string? title, int authorId, string content)
    {
        Title = title;
        AuthorId = authorId;
        Content = content;
    }
    

    private Post()
    {
    }
    

    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public User Author { get; private set; }
    public int AuthorId { get; set; }
    public string Content { get; set; }
    public DateTime PostDate { get; set; }
    public int Score { get; set; }
    public List<Post>? Comments { get; set; }
}