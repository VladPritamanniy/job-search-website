namespace JobSearch.BLL.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
    }
}
