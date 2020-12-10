using System.Collections.Generic;
using System.Linq;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["UserNickname"] = HttpContext.Session.GetString("UserNickname");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");

            var friends = new List<User>();
            
            using (var db = new ApplicationContext())
            {
                friends = db.Users.ToList();
            }

            return View();
        }
    }
}
