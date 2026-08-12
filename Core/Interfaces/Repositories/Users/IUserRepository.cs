using Core.Common.Results;
using Core.Entities;

namespace Core.Interfaces.Repositories.Users;

public interface IUserRepository
{
    Task<Result> AddUserAsync(User user);
    Task<Result> RemoveUserAsync(User user);
    Task<Result<User>> GetUserByEmail(string email);
}