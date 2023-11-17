using System.ComponentModel.DataAnnotations;
using Domain.Models;
using EfcDataAccess;
using EfcDataAccess.DAOs;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly UserEFCDao users = new(new ReaditContext());

    public Task<User> ValidateUser(string username, string password)
    {
        var existingUser = users.GetByUsernameAsync(username);

        if (existingUser == null) throw new Exception("User not found");

        if (!existingUser.Result.PassWord.Equals(password)) throw new Exception("Password mismatch");

        return existingUser;
    }

    public Task<User> GetUser(string username, string password)
    {
        var existingUser = users.GetByUsernameAsync(username);

        if (existingUser == null) throw new Exception("User not found");

        return existingUser;
    }

    public Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.UserName)) throw new ValidationException("Username cannot be null");

        if (string.IsNullOrEmpty(user.PassWord)) throw new ValidationException("Password cannot be null");
        // Do more user info validation here

        users.CreateAsync(user);

        return Task.CompletedTask;
    }
}