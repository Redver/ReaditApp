using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;

namespace BlazorWasm.Services.Http;

public class JwtAuthService : IAuthService
{
    private readonly HttpClient client = new();

    // this private variable for simple caching
    public static string? Jwt { get; private set; } = "";

    public async Task LoginAsync(string username, string password)
    {
        UserLoginDto userLoginDto = new()
        {
            Username = username,
            Password = password
        };

        var userAsJson = JsonSerializer.Serialize(userLoginDto);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://localhost:7130/auth/login", content);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);

        var token = responseContent;
        Jwt = token;

        var principal = CreateClaimsPrincipal();

        OnAuthStateChanged.Invoke(principal);
    }

    public async Task LogoutAsync()
    {
        Jwt = null;
        
        var anonymousPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        OnAuthStateChanged.Invoke(anonymousPrincipal);
    }

    public async Task RegisterAsync(string username, string password)
    {
        UserLoginDto userLoginDto = new()
        {
            Username = username,
            Password = password
        };

        var userAsJson = JsonSerializer.Serialize(userLoginDto);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://localhost:7130/User", content);
        
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(responseContent);

    }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        var principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }


    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }

    private static ClaimsPrincipal CreateClaimsPrincipal()
    {
        if (string.IsNullOrEmpty(Jwt)) return new ClaimsPrincipal();

        var claims = ParseClaimsFromJwt(Jwt);

        ClaimsIdentity identity = new(claims, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }
}