using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class User
{
    public string? UserName { get; set; }
    public string? PassWord { get; set; }
    [Key]
    public int Id { get; set; }
    public int? Coins { get; set; }
    public ICollection<Post> Posts { get; set; }
    
    public User(){}
}