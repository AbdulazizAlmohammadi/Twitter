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

