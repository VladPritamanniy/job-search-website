using JobSearch.BLL.DTO;

namespace JobSearch.BLL.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
        string GenerateRefreshToken();
    }
}
