using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class GoJourneyController : Controller
    {
        public IActionResult Index()
        {
            ViewData["UserNickname"] = HttpContext.Session.GetString("UserNickname");
            ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            ViewData["UserSurname"] = HttpContext.Session.GetString("UserSurname");

            return View();
        }
    }
}
