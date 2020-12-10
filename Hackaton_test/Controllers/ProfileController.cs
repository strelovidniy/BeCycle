using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Hackaton_test.Models;

namespace Hackaton_test.Controllers
{
    public class ProfileController : Controller
    {
    //    public IActionResult Index(int id)
    //    {
    //        using (var dbContext = new ApplicationContext())
    //        {
    //            ViewData["User"] = dbContext.Users.Where(user => user.UserId == id).FirstOrDefault();

    //            if (ViewData["User"] == null)
    //            {
    //                return Redirect("~/");
    //            }
    //        }

    //        return View();
    //    }

        public IActionResult Index(string username)
        {
            using (var dbContext = new ApplicationContext())
            {
                ViewData["User"] = dbContext.Users.Where(user => user.NickName == username).FirstOrDefault();

                if (ViewData["User"] == null)
                {
                    return Redirect("~/");
                }
            }

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Update([FromForm] User user)
        //{
        //    return null;
        //}
    }
}
