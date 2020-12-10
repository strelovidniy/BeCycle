using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hackaton_test.Models;

namespace Hackaton_test.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index(string username)
        {
            using (var dbContext = new ApplicationContext())
            {
                ViewData["User"] = dbContext.Users.FirstOrDefault(user => user.NickName == username);

                if (ViewData["User"] == null)
                {
                    return Redirect("~/");
                }
            }

            return View();
        }

        public IActionResult Achievements(string username)
        {
            using (var dbContext = new ApplicationContext())
            {
                ViewData["UserAchievements"] =
                    dbContext.Users.FirstOrDefault(user => user.NickName == username)?.UserAchievements;
            }

            if (ViewData["UserAchievements"] != null)
            {
                return View();
            }

            return Redirect("~/Home");
        }
    }
}
