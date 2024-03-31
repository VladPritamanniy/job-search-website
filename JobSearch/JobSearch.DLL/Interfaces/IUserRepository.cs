using JobSearch.DLL.Entities;

namespace JobSearch.DLL.Interfaces
{
    public interface IUserRepository
    {
        Task Add(UserEntity userEntity);

        Task<UserEntity> GetByEmail(string email);

        Task Update(UserEntity userEntity);

        Task<UserEntity> GetById(int id);
    }
}
