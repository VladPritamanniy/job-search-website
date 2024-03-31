using JobSearch.BLL.DTO;

namespace JobSearch.BLL.Interfaces
{
    public interface IUserService
    {
        Task Register(string email, string password);
        Task<RefreshTokenOptions> Login(string email, string password);
        Task<RefreshTokenOptions> RefreshAccessToken(string accessToken, string refreshToken);
    }
}
