using System.Collections.ObjectModel;
using Domain.Models;

namespace Domain.DTOs;

public class PostUpdateDto
{
    public PostUpdateDto(int postId, string commenter, string comment)
    {
        PostId = postId;
        Comment = comment;
        Commenter = commenter;

    }

    public int PostId { get; set; }

    public string Commenter { get; set; }

    public string Comment { get; set; }
}