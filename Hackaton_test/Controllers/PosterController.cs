using System.Linq;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class PosterController:Controller
    {
        public IActionResult Index(int id)
        {
            Poster poster;

            using (var db = new ApplicationContext())
            {
                poster = db.Posters.FirstOrDefault(p => p.PosterId == id);
            }

            return View(poster);
        }
    }
}