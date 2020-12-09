using Microsoft.AspNetCore.Mvc;
using Hackaton_test.Models;
using Hackaton_test.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class PosterCreationController : Controller
    {
        // GET
       
        public IActionResult Index()
        {
            Poster poster = new Poster();
            return View(poster);
        }
    }
}