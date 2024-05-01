using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.DLL.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO WorkFormats (Name) VALUES ('Remote work');" +
                                 "INSERT INTO WorkFormats (Name) VALUES ('In office/On site');" +
                                 "INSERT INTO WorkFormats (Name) VALUES ('Hybrid format');");

            migrationBuilder.Sql("INSERT INTO EmploymentTypes (Name) VALUES ('Full employment');" +
                                 "INSERT INTO EmploymentTypes (Name) VALUES ('Part-time employment');" +
                                 "INSERT INTO EmploymentTypes (Name) VALUES ('Internship');");

            migrationBuilder.Sql("INSERT INTO Experiences (Name) VALUES ('No experience');" +
                                 "INSERT INTO Experiences (Name) VALUES ('< 1 year');" +
                                 "INSERT INTO Experiences (Name) VALUES ('1-2 years');" +
                                 "INSERT INTO Experiences (Name) VALUES ('3-5 years');" +
                                 "INSERT INTO Experiences (Name) VALUES ('5+ years');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
