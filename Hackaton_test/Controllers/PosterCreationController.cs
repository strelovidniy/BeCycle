using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    public class PosterCreationController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}