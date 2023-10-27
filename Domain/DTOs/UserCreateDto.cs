namespace Domain.DTOs;

public class UserCreateDto
{
    public UserCreateDto(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; }
    public string Password { get; }
}