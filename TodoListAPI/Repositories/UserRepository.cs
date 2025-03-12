using Azure.Core;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Model;

namespace TodoListAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<AppUser?> GetUserByUsername(string username)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            return result;
        }

        public async Task<bool> GetUsername(string username)
        {
            var result = await _context.Users.AnyAsync(u => u.Username == username);

            return result;
        }
    }
}
