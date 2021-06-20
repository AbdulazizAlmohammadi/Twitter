using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var profiles = _db.Profiles.ToList();
            ViewData["profiles"] = profiles;
            return View();
        }
        //GET - /profile/edit/id
        public IActionResult Edit(int? id)
        {
            // ViewData["ProfileId"] = id;
            var profile = _db.Profiles.ToList().Find(b => b.ProfileId == id);
            if (id == null || profile == null)
            {
                return View("_NotFound");
            }
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
