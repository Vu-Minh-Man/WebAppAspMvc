using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppAspMvc.Migrations
{
    public partial class PopulateGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Romance')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Drama')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
