
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
    public Post()
    {
    }
    

    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public User Author { get; set; }
    public int AuthorId { get; set; }
    public string Content { get; set; }
    public DateTime PostDate { get; set; }
    public int Score { get; set; }
}