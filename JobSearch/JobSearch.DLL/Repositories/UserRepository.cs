using JobSearch.DLL.Context;
using JobSearch.DLL.Entities;
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

        public async Task Add(UserEntity userEntity)
        {
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserEntity> GetById(int id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Update(UserEntity userEntity)
        {
            await _context.Users.Where(c => c.Email == userEntity.Email).ExecuteUpdateAsync(s => s
                .SetProperty(c => c.RefreshToken, userEntity.RefreshToken)
                .SetProperty(c => c.RefreshTokenExpiry, userEntity.RefreshTokenExpiry)
            );
            await _context.SaveChangesAsync();
        }
    }
}
