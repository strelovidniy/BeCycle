using Hackaton_test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

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