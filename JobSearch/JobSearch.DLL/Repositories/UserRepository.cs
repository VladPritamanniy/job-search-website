using JobSearch.DLL.Context;
using JobSearch.DLL.EfClasses;
using Microsoft.EntityFrameworkCore;
using JobSearch.DLL.Interfaces;

namespace JobSearch.DLL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JobSearchContext _context;
        public UserRepository(JobSearchContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.UserId == id);
        }

        public async Task Update(User user)
        {
            await _context.Users.Where(u => u.Email == user.Email).ExecuteUpdateAsync(s => s
                .SetProperty(u => u.RefreshToken, user.RefreshToken)
                .SetProperty(u => u.RefreshTokenExpiry, user.RefreshTokenExpiry)
            );
            await _context.SaveChangesAsync();
        }
    }
}
