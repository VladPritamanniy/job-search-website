using JobSearch.DAL.EfClasses;

namespace JobSearch.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user);

        Task<User> GetByEmail(string email);

        Task Update(User user);

        Task<User> GetById(int id);
    }
}
