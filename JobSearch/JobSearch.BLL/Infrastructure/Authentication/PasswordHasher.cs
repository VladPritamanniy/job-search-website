using JobSearch.BLL.Interfaces;

namespace JobSearch.BLL.Infrastructure.Authentication
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password)
        {
            return string.IsNullOrEmpty(password) ? string.Empty : BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool Verify(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            {
                return false;
            }
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}
