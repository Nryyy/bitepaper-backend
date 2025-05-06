using BitePaper.Infrastructure.Interfaces.Users;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.Users;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User?> GetByIdAsync(string id)
    {
        return await userRepository.GetByIdAsync(id);
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return userRepository.GetByEmailAsync(email);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await userRepository.GetAllAsync();
    }

    public async Task AddAsync(User user)
    {
        await userRepository.AddAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        await userRepository.UpdateAsync(user);
    }

    public async Task DeleteAsync(string id)
    {
        await userRepository.DeleteAsync(id);
    }
}