using Domain.Models;

namespace Domain.DTOs;

public class PostCreateDto
{
    public PostCreateDto(string title, User author, string content)
    {
        Title = title;
        Author = author;
        Content = content;
    }

    public string? Title { get; set; }
    public User Author { get; set; }
    public string Content { get; set; }
}