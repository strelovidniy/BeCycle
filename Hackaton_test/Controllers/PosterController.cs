using Hackaton_test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class PosterController:Controller
    {
        public IActionResult Index(int id)
        {
            Poster poster;

            using (var db = new ApplicationContext())
            {
                poster = db.Posters.First(poster => poster.PosterId == id);
            }

            ViewData["UserId"] = HttpContext.Session.GetInt32("UserId");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");

            return View(poster);
        }
    }
}