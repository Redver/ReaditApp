using System.Security.Claims;
using Domain.Models;

namespace BlazorWasm.Services;

public interface IAuthService
{
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    public Task RegisterAsync(string username, string password);
    public Task<ClaimsPrincipal> GetAuthAsync();
}