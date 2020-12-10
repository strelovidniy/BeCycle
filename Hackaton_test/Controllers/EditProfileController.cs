using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hackaton_test.Models;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class EditProfileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["UserId"] = HttpContext.Session.GetInt32("UserId");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");
            ViewData["UserNickname"] = HttpContext.Session.GetString("UserNickname");
            ViewData["UserPhone"] = HttpContext.Session.GetString("UserPhone");
            ViewData["UserEmail"] = HttpContext.Session.GetString("UserEmail");

            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            string userInfo = $"FirstName: {user.FirstName}, LastName: {user.LastName}, NickName: {user.NickName}, " +
                              $"Age: {user.Age}, Email: {user.Email}, PhoneNumber: {user.PhoneNumber}";
            return Content(userInfo);
        }
    }
}
