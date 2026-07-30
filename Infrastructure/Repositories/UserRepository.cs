using Microsoft.EntityFrameworkCore;

using AutoMapper;

using Core.Enums;
using Core.Common;
using Core.Entities;

using Infrastructure.Factories;
using Infrastructure.Database.Enitites.Auth;
using Core.Interfaces.Repositories.Users;

namespace Infrastructure.Repositories;

public class UserRepository(
    DbContextFactory factory,
    IMapper mapper) : IUserRepository
{
    public async Task<Result> AddUserAsync(User user)
    {
        await using var context = factory.CreateDbContext(TargetDbType.SMODB18);

        var exists = await context.Users.AnyAsync(dbUser => dbUser.Username == user.Username);

        if (exists)
        {
            return Result.Failure(
                error: "Пользователь с данной почтой уже существует", 
                clientMessage: "Пользователь с данной почтой уже существует");
        }

        var newUser = mapper.Map<UserEntity>(user);
        await context.Users.AddAsync(newUser);
        await context.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> RemoveUserAsync(User user)
    {
        await using var context = factory.CreateDbContext(TargetDbType.SMODB18);

        var dbUser = await context.Users.FirstOrDefaultAsync(dbUser => dbUser.Username == user.Username);

        if (dbUser is null)
        {
            return Result.Failure("Пользователя не существует");
        }

        context.Users.Remove(dbUser);
        await context.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<User>> GetUserByEmail(string email)
    {
        await using var context = factory.CreateDbContext(TargetDbType.SMODB18);

        var targetUser = await context.Users.FirstOrDefaultAsync(dbUser => dbUser.Email == email);

        if(targetUser is null)
        {
            return Result<User>.Failure("Пользователя с данной почтой не найдено");
        }

        return Result<User>.Success(mapper.Map<User>(targetUser));
    }
}
