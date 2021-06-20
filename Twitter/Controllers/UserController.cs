using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Data;
using Twitter.Models;
using Microsoft.AspNetCore.Http;

namespace Twitter.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext context)
        {
            _db = context;
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserModel NewUser)
        {
            var user = new UserModel()
            {
                userId= NewUser.userId,
                userEmail= NewUser.userEmail,
                username= NewUser.username,
                password= NewUser.password
            };
            _db.Add(user);
            _db.SaveChanges(); 
            
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult LoginVerification(UserModel userData)
        {
            var targetUser = _db.Users.Where(user => user.userEmail == userData.userEmail).SingleOrDefault();

            if (targetUser == null) {

                return View("login");
                
            }
            else if (targetUser.userEmail == userData.userEmail && targetUser.password == userData.password)
            {
                HttpContext.Session.SetString ("UserEmail",targetUser.userEmail);
                HttpContext.Session.SetString("UserName", targetUser.username);
                HttpContext.Session.SetInt32("UserId",targetUser.userId);
                    
                return RedirectToAction("Index" , "Home");

            } else
            {
                ViewBag.Message = "Incorrect Password/Email";
                return BadRequest();

            }
            
            
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserEmail");
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("UserId");

            return RedirectToAction("Index","Home");
        }

    }
}
