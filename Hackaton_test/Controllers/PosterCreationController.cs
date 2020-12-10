using Microsoft.AspNetCore.Mvc;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class PosterCreationController : Controller
    {
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["UserId"] = HttpContext.Session.GetInt32("UserId");
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

            var posterData = $"Title: {poster.Title}, Description: {poster.Description}," +
                             $" EventDate: {poster.EventDate},  " +
                             $"Sport Type: {poster.SportType}, " +
                             $"UserId: {poster.AuthorId = 1}, ";

            HttpContext.Session.GetInt32("UserId");

            return Content(posterData);
        }
    }
}