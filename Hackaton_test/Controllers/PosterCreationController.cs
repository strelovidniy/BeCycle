using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class PosterCreationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var claimsData = ((ClaimsIdentity)HttpContext.User.Identity)?.Claims;

            var claimsDictionary = claimsData?
                .ToDictionary(key => key.Type.Split('/',
                        StringSplitOptions.RemoveEmptyEntries).TakeLast(1).FirstOrDefault(),
                    value => value.Value);

            ViewData["UserEmail"] = claimsDictionary?["emailaddress"];
            ViewData["UserName"] = claimsDictionary?["givenname"];
            ViewData["UserSurname"] = claimsDictionary?["surname"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Poster poster)
        {
            using (var db = new ApplicationContext())
            {
                var claimsData = ((ClaimsIdentity)HttpContext.User.Identity)?.Claims;
                var claimsDictionary = claimsData?
                    .ToDictionary(key => key.Type.Split('/', 
                            StringSplitOptions.RemoveEmptyEntries).TakeLast(1).FirstOrDefault(),
                        value => value.Value);

                var email = claimsDictionary?["emailaddress"];
                var currentUser = db.Users.FirstOrDefault(u => u.Email == email);

                ViewData["UserName"] = currentUser?.FirstName;
                ViewData["UserSurname"] = currentUser?.LastName;

                poster.PublicationDate = DateTime.Now;
                
                if (currentUser != null)
                {
                    poster.AuthorId = currentUser.UserId;
                    
                    var enPoster = await db.Posters.AddAsync(poster);
                    
                    await db.SaveChangesAsync(true);
                
                    return RedirectToAction("Index", "Poster", new {id = enPoster.Entity.PosterId });
                }
                
                return RedirectToRoute("~account/google-signin");
            }
        }
    }
}