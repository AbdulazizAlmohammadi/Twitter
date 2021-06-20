using Microsoft.EntityFrameworkCore.Migrations;

namespace Twitter.Migrations
{
    public partial class EditprofilePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Tweets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Tweets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
