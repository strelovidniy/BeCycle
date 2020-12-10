using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class PosterCreationController : Controller
    {
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["UserNickname"] = HttpContext.Session.GetString("UserNickname");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");

            return View();
        }

        [HttpPost]
        public IActionResult Index(Poster poster)
        {
            ViewData["UserId"] = HttpContext.Session.GetInt32("UserId");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");

            User currentUser;
            EntityEntry<Poster> enPoster;

            using (var db = new ApplicationContext())
            {
                currentUser = db.Users.First(us => us.UserId == (int)ViewData["UserId"] );
            }
            
            var newPoster = new Poster()
            {
                Title = poster.Title,
                Description =  poster.Description,
                EventDate =  poster.EventDate,
                PublicationDate =  DateTime.Now,
                SportType =  poster.SportType,
                Author = currentUser, AuthorId = (int)ViewData["UserId"]
            };
       
            using (var db = new ApplicationContext())
            {
               enPoster = db.Posters.Add(newPoster);
            }

            return RedirectToAction("Index", "Poster", new {enPoster.Entity.PosterId});
        }
    }
}