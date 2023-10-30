namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public string? username { get; }
    public string? titleContains { get; }
    public string? bodyContains { get; }

    public SearchPostParametersDto(string? username, string? titleContains, string? bodyContains)
    {
        this.username = username;
        this.titleContains = titleContains;
        this.bodyContains = bodyContains;
    }
}