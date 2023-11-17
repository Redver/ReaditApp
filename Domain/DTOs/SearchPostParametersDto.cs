namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public string? username { get; }
    public string? titleContains { get; }
    public string? bodyContains { get; }
    public int id { get; }

    public SearchPostParametersDto(string? username, string? titleContains, string? bodyContains, int id)
    {
        this.username = username;
        this.titleContains = titleContains;
        this.bodyContains = bodyContains;
        this.id = id;
    }
}