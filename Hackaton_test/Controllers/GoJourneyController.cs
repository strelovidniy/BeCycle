using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class GoJourneyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
