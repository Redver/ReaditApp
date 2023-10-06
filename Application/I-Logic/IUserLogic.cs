using Domain.DTOs;
using Domain.Models;

namespace Application.I_Logic;

public interface IUserLogic
{
    Task<User> CreateUserAsync(UserCreateDto userToCreate);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
}