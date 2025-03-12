using TodoListAPI.Model;

namespace TodoListAPI.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(AppUser user);
        Task<bool> GetUsername(string username);
        Task<AppUser?> GetUserByUsername(string username);
    }
}
