using System.Collections.ObjectModel;
using Domain.Models;

namespace Domain.DTOs;

public class AddCommentToPostDto
{
    public AddCommentToPostDto(int postId,Collection<Post> comments)
    {
        PostId = postId;
        Comments = comments;
    }

    public int PostId { get; set; }

    public Collection<Post> Comments { get; set; }
}