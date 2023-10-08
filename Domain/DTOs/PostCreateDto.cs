namespace Domain.DTOs;

public class PostCreateDto
{
    public string? Title { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }

    public PostCreateDto(string title,string author,string content)
    {
        Title = title;
        Author = author;
        Content = content;
    }
}