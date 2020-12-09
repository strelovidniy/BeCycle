using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    public class GoJourneyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
