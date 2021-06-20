using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //add table Tweet 
        public DbSet<TweetModel> Tweets { get; set; }
        //add table Follow 
        public DbSet<FollowModel> Follow { get; set; }
        //add table User 
        public DbSet<UserModel> Users { get; set; }
        //add table Profile 
        public DbSet<ProfileModel> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Seeding user
            builder.Entity<UserModel>().HasData(new UserModel { userId = 1, username = "nada", userEmail = "nada@hotmail.com", password = "1234" });
            builder.Entity<UserModel>().HasData(new UserModel { userId = 2, username = "yasmin", userEmail = "yasmin@hotmail.com", password = "112233" });
            builder.Entity<UserModel>().HasData(new UserModel { userId = 3, username = "taif", userEmail = "taif@hotmail.com", password = "9988" });

            //Seeding tweet//"MM/dd/yyyy HH:mm:ss"
            builder.Entity<TweetModel>().HasData(new TweetModel { TweetId = 1, TweetContent = "Hi I am new member here", TweetDate = DateTime.ParseExact("2005-09-01", "yyyy-MM-dd", null), UserId = 1 });
            builder.Entity<TweetModel>().HasData(new TweetModel { TweetId = 2, TweetContent = "I like MVC and c#", TweetDate = DateTime.ParseExact("2019-09-09", "yyyy-MM-dd", null), UserId = 2 });
            builder.Entity<TweetModel>().HasData(new TweetModel { TweetId = 3, TweetContent = "Do you want to learn more about FrontEnd?", TweetDate = DateTime.ParseExact("2010-09-07", "yyyy-MM-dd", null), UserId = 3 });

            //Seeding profile 

            builder.Entity<ProfileModel>().HasData(new ProfileModel { ProfileId = 1, ProfileName = "Nada", ProfilePicture = "https://i.pinimg.com/originals/0a/53/c3/0a53c3bbe2f56a1ddac34ea04a26be98.jpg", Bio = "Hardcore coffeeaholic. Thinker. Twitter maven. Problem solver. Evil travel lover.", TotalFollowers = 34, TotalFollowing = 434, NumberOfTweets = 31, DateOfJoin = DateTime.ParseExact("2015-09-01", "yyyy-MM-dd", null), UserId = 1 });
            builder.Entity<ProfileModel>().HasData(new ProfileModel { ProfileId = 2, ProfileName = "I love cats", ProfilePicture = "https://i.redd.it/v0caqchbtn741.jpg", Bio = "Pop culture evangelist. Devoted internet nerd. Tv fanatic. Web maven. Typical travel aficionado. Thinker.", TotalFollowers = 1000, TotalFollowing = 234, NumberOfTweets = 752, DateOfJoin = DateTime.ParseExact("2011-03-05", "yyyy-MM-dd", null), UserId = 2 });
            builder.Entity<ProfileModel>().HasData(new ProfileModel { ProfileId = 3, ProfileName = "Taif", ProfilePicture = "https://i.pinimg.com/originals/bc/b8/36/bcb83616190f26847422d44363434400.jpg", Bio = "Wannabe bacon geek. Social media evangelist. Web maven. Twitter scholar. ", TotalFollowers = 200, TotalFollowing = 4534, NumberOfTweets = 435, DateOfJoin = DateTime.ParseExact("2017-07-11", "yyyy-MM-dd", null), UserId = 3 });
            /*            builder.Entity<ProfileModel>().HasData(new ProfileModel { ProfileId = 4, ProfileName = "Yasmin", ProfilePicture = "https://i.pinimg.com/originals/18/99/07/1899072ff62e9455aed4c53be5fe9654.png", Bio = "Friendly analyst. Beer aficionado. Reader. ", TotalFollowers = 3224, TotalFollowing = 126, NumberOfTweets = 235, DateOfJoin = DateTime.ParseExact("2012-12-12", "yyyy-MM-dd", null) });
                        builder.Entity<ProfileModel>().HasData(new ProfileModel { ProfileId = 5, ProfileName = "Taif", ProfilePicture = "https://p77-sg.tiktokcdn.com/musically-maliva-obj/0542cb7417e2358d8b3faa48f62e0f73~c5_720x720.jpeg", Bio = "Subtly charming thinker. Internet enthusiast. Food practitioner. Music evangelist.", TotalFollowers = 342, TotalFollowing = 3234, NumberOfTweets = 3454, DateOfJoin = DateTime.ParseExact("2019-02-04", "yyyy-MM-dd", null) });*/

            builder.Entity<UserModel>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Following)
                .UsingEntity<FollowModel>(
                    j => j
                        .HasOne(e=>e.user)
                        .WithMany(ee=>ee.UserFollowers)
                        .HasForeignKey(t=>t.userId),
                    j => j
                        .HasOne(e=>e.follower)
                        .WithMany(e=>e.UserFollowing)
                        .HasForeignKey(t=>t.followerId),
                    j =>
                    {
                        j.HasKey(t => new { t.userId, t.followerId });
                    }
                );
           
        }

    }
    }


