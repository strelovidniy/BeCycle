using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Poster> list;

            using (var db = new ApplicationContext())
            {
               list = db.Posters.OrderByDescending(pos=>pos.EventDate).ToList();
            }

            ViewData["UserNickname"] = HttpContext.Session.GetString("UserNickname");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");

            return View(list);
        }
        public IActionResult IndexWithSportType(SportType sportType)
        {
            List<Poster> list;

            using (var db = new ApplicationContext())
            {
                list = db.Posters.Where(pos=> pos.SportType == sportType).ToList();
            }

            ViewData["UserNickname"] = HttpContext.Session.GetString("UserNickname");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");
            ViewBag.CurrentSportType = sportType;
            return View("Index", list);
        }
        
        public IActionResult Following()
        {
            List<Poster> list;

            using (var db = new ApplicationContext())
            {
            //вибрати всі постери на які підписаний поточний юзер
          
               
                
                
                
            }

            ViewData["UserNickname"] = HttpContext.Session.GetString("UserNickname");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");
           return View("Index");
        }
        
        
        
      
        public IActionResult StartFollowing(int id)
        {
            ViewData["UserId"] = HttpContext.Session.GetInt32("UserId");
            User currentUser;
            Poster currentPoster;
            using (var db = new ApplicationContext())
            {
                currentUser = db.Users.FirstOrDefault(us => us.UserId == (int)ViewData["UserId"] );
                currentPoster = db.Posters.FirstOrDefault(pos => pos.PosterId == id);
            }
            
            EventFollower eventFollower = new EventFollower()
            {
                Event = currentPoster, Follower = currentUser, EventId = id, FollowerId = (int)ViewData["UserId"]
            };
            currentUser.EventFollowers.Add(eventFollower);
            currentPoster.EventFollowers.Add(eventFollower);
            return RedirectToAction("Index", "Home");
        }
    }
    
}
