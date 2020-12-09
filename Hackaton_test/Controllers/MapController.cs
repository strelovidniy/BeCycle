using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}