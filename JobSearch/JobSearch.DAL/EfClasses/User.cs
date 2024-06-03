using System.ComponentModel.DataAnnotations;

namespace JobSearch.DAL.EfClasses;

public class User
{
    public int UserId { get; set; }

    [MaxLength(256)]
    public string Email { get; set; }

    [MaxLength(256)]
    public string PasswordHash { get; set; }

    [MaxLength(256)]
    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiry { get; set; }
}
