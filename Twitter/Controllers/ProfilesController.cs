﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProfilesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult FollowUser(int id)
        {
            var loggedInUserId = (int)HttpContext.Session.GetInt32("UserId");
            var user = new FollowModel()
            {
                userId = id,
                followerId = loggedInUserId
            };
            _db.Follow.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UnfollowUser(int userId)
        {
            var loggedInUserId = (int)HttpContext.Session.GetInt32("UserId");
            var follow = _db.Follow.Where(e => e.userId == userId).Where(e => e.followerId == loggedInUserId).FirstOrDefault();

            if(follow != null)
            {
                _db.Follow.Remove(follow);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var userId =  HttpContext.Session.GetInt32("UserId");
            var profile = _db.Profiles.FirstOrDefault(p => p.UserId == HttpContext.Session.GetInt32("UserId"));
            if(profile == null && userId != null){
                
                var userName = HttpContext.Session.GetString("UserName");
                var userProfile = new ProfileModel(){UserId =(int)userId , ProfileName = userName};
                _db.Add(userProfile);
                _db.SaveChanges();
                profile = userProfile;
            }
            
            var tweets = _db.Tweets.Where(t => t.UserId == (int)userId).ToList();
                
            ViewData["Tweets"] = tweets;
            ViewData["profiles"] = profile;
            ViewData["FollowersCount"] = _db.Users.Where(e => e.userId == profile.UserId).Include(u => u.Followers).Single().Followers.Count();
            ViewData["FollowingCount"] = _db.Users.Where(e => e.userId == profile.UserId).Include(u => u.Following).Single().Following.Count();
            ViewData["otherUser"] = false;
            return View();
        }
        
        public IActionResult UserProfile(int id)
        {
            var userId =  id;
            var user = _db.Users.FirstOrDefault(u => u.userId == id);
            var profile = _db.Profiles.FirstOrDefault(p => p.UserId == id);
            if(profile == null && userId != null){
                
                var userName = user.username;
                var userProfile = new ProfileModel(){UserId =(int)userId , ProfileName = userName};
                _db.Add(userProfile);
                _db.SaveChanges();
                profile = userProfile;
            }
            
            var tweets = _db.Tweets.Where(t => t.UserId == (int)userId).ToList();
                
            ViewData["Tweets"] = tweets;
            ViewData["profiles"] = profile;
            ViewData["FollowersCount"] = _db.Users.Where(e => e.userId == profile.UserId).Include(u => u.Followers).Single().Followers.Count();
            ViewData["FollowingCount"] = _db.Users.Where(e => e.userId == profile.UserId).Include(u => u.Following).Single().Following.Count();
            ViewData["otherUser"] = true;
            return View("Index");
        }
        //GET - /profile/edit/id
        public IActionResult Edit(int? id)
        {
            // ViewData["ProfileId"] = id;
            var profile = _db.Profiles.ToList().Find(b => b.ProfileId == id);
            /*if (id == null || profile == null)
            {
                return View("_NotFound");
            }*/
            ViewData["profile"] = profile;
            return View();
        }
        // POST - // profile/edit/id
        [HttpPost]
        public IActionResult Edit(int id, [Bind("ProfileName", "ProfilePicture", "Bio", "TotalFollowers", "TotalFollowing", "NumberOfTweets", "DateOfJoin")] ProfileModel profile)
        {
            //profile.ProfileId = id;
            var prof  = _db.Profiles.ToList().Find(p => p.ProfileId == id);

            prof.ProfileName = profile.ProfileName;
            prof.ProfilePicture = profile.ProfilePicture;
            prof.Bio = profile.Bio;
            prof.TotalFollowers = profile.TotalFollowers;
            prof.TotalFollowing = profile.TotalFollowing;
            prof.NumberOfTweets = profile.NumberOfTweets;
            prof.DateOfJoin = profile.DateOfJoin;

            _db.Update(prof);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }


    }
}
