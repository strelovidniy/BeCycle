using Hackaton_test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Hackaton_test.Controllers
{
    public class PosterController:Controller
    {
        public IActionResult Index(int id)
        {
            Poster poster;

            using (var db = new ApplicationContext())
            {
                poster = db.Posters.First(poster => poster.PosterId == id);
            }
            return View(poster);
        }
    }
}