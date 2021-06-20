using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Twitter.Migrations
{
    public partial class SeedingUserAndTweetAndProfileTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "password", "userEmail", "username" },
                values: new object[] { 1, "1234", "nada@hotmail.com", "nada" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "password", "userEmail", "username" },
                values: new object[] { 2, "112233", "yasmin@hotmail.com", "yasmin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "password", "userEmail", "username" },
                values: new object[] { 3, "9988", "taif@hotmail.com", "taif" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "Bio", "DateOfJoin", "NumberOfTweets", "ProfileName", "ProfilePicture", "TotalFollowers", "TotalFollowing", "UserId" },
                values: new object[,]
                {
                    { 1, "Hardcore coffeeaholic. Thinker. Twitter maven. Problem solver. Evil travel lover.", new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Nada", "https://i.pinimg.com/originals/0a/53/c3/0a53c3bbe2f56a1ddac34ea04a26be98.jpg", 34, 434, 1 },
                    { 2, "Pop culture evangelist. Devoted internet nerd. Tv fanatic. Web maven. Typical travel aficionado. Thinker.", new DateTime(2011, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 752, "I love cats", "https://i.redd.it/v0caqchbtn741.jpg", 1000, 234, 2 },
                    { 3, "Wannabe bacon geek. Social media evangelist. Web maven. Twitter scholar. ", new DateTime(2017, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 435, "Taif", "https://i.pinimg.com/originals/bc/b8/36/bcb83616190f26847422d44363434400.jpg", 200, 4534, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tweets",
                columns: new[] { "TweetId", "TweetContent", "TweetDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Hi I am new member here", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "I like MVC and c#", new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "Do you want to learn more about FrontEnd?", new DateTime(2010, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "ProfileId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tweets",
                keyColumn: "TweetId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tweets",
                keyColumn: "TweetId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tweets",
                keyColumn: "TweetId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3);
        }
    }
}
