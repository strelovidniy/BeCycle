using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    public class FriendsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
