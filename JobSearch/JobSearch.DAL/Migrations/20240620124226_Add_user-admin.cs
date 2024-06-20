using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_useradmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty");
            migrationBuilder.Sql($"INSERT INTO Users (Email, PasswordHash) VALUES ('admin@gmail.com', '{passwordHash}')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users WHERE Email='admin@gmail.com'");
        }
    }
}
