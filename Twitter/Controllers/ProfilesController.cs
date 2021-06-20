using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            return View();
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
