namespace Domain.DTOs;

public class UserCreateDto
{
    public string UserName { get;}
    public string Password { get; }

    public UserCreateDto(string userName,string password)
    {
        UserName = userName;
        Password = password;
    }
}