
namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
    public DateTime PostDate { get; set; }
    public int Score { get; set; }
    public List<Post> Comments { get; set; }
}