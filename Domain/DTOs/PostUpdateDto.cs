using System.Collections.ObjectModel;
using System.Runtime.InteropServices.JavaScript;
using Domain.Models;

namespace Domain.DTOs;

public class PostUpdateDto
{
    public int? PostId { get; set; }

    public string? Commenter { get; set; }

    public string? Comment { get; set; }

    public string? PostAuthor { get; set; }

    public string? PostTitle { get; set; }
    public string? PostBody { get; set; }
    public DateTime? PostDateTime { get; set; }
    public List<Post>? PostComments { get; set; }



    public PostUpdateDto(int? postId,string? postAuthor, string? postTitle,string? postBody,DateTime? postDateTime, string? commenter, string? comment,List<Post>? postComments)
    {
        PostId = postId;
        Comment = comment;
        Commenter = commenter;
        PostAuthor = postAuthor;
        PostTitle = postTitle;
        PostBody = postBody;
        PostDateTime = postDateTime;
        PostComments = postComments;
    }
    
    public PostUpdateDto(){}

}