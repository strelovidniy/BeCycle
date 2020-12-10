using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Poster> list;
            var claimsData = ((ClaimsIdentity)HttpContext.User.Identity)?.Claims;
            if (claimsData.Count() != 0)
            {
                var claimsDictionary = claimsData?
                    .ToDictionary(key => key.Type.Split('/',
                            StringSplitOptions.RemoveEmptyEntries).TakeLast(1).FirstOrDefault(),
                        value => value.Value);

                ViewData["UserEmail"] = claimsDictionary?["emailaddress"];
                ViewData["UserNickName"] = claimsDictionary?["emailaddress"].TakeWhile(ch => ch != '@')
                    .Aggregate("", (s, c) => s + c);
                ViewData["UserName"] = claimsDictionary?["givenname"];
                ViewData["UserSurname"] = claimsDictionary?["surname"];
            }

            using (var db = new ApplicationContext())
            {
                list = db.Posters.OrderByDescending(pos => pos.EventDate).ToList();
            }

            return View(list);
        }

        public IActionResult IndexWithSportType(SportType sportType)
        {
            List<Poster> list;

            using (var db = new ApplicationContext())
            {
                list = db.Posters.Where(pos => pos.SportType == sportType).ToList();
            }

            var claimsData = ((ClaimsIdentity)HttpContext.User.Identity)?.Claims;
            var claimsDictionary = claimsData?
                .ToDictionary(key => key.Type.Split('/',
                        StringSplitOptions.RemoveEmptyEntries).TakeLast(1).FirstOrDefault(),
                    value => value.Value);

            ViewData["UserEmail"] = claimsDictionary?["emailaddress"];
            ViewData["UserNickName"] = claimsDictionary?["emailaddress"].TakeWhile(ch => ch != '@')
                .Aggregate("", (s, c) => s + c);
            ViewData["UserName"] = claimsDictionary?["givenname"];
            ViewData["UserSurname"] = claimsDictionary?["surname"];
            ViewBag.CurrentSportType = sportType;

            return View("Index", list);
        }

        public IActionResult Following()
        {
            var claimsData = ((ClaimsIdentity)HttpContext.User.Identity)?.Claims;
            var claimsDictionary = claimsData?
                .ToDictionary(key => key.Type.Split('/',
                        StringSplitOptions.RemoveEmptyEntries).TakeLast(1).FirstOrDefault(),
                    value => value.Value);

            ViewData["UserEmail"] = claimsDictionary?["emailaddress"];
            ViewData["UserNickName"] = claimsDictionary?["emailaddress"].TakeWhile(ch => ch != '@')
                .Aggregate("", (s, c) => s + c);
            ViewData["UserName"] = claimsDictionary?["givenname"];
            ViewData["UserSurname"] = claimsDictionary?["surname"];

            List<Poster> posters;

            using (var dbContext = new ApplicationContext())
            {
                var currentUser = dbContext.Users.FirstOrDefault(u => u.Email == (string) ViewData["UserEmail"]);
                posters = currentUser.EventFollowers.Select(ef => ef.Event).ToList();
                dbContext.SaveChanges(true);
               
            }
            return View("Index", posters);
        }

        public IActionResult StartFollowing(int id)
        {
            var claimsData = ((ClaimsIdentity)HttpContext.User.Identity)?.Claims;
            var claimsDictionary = claimsData?
                .ToDictionary(key => key.Type.Split('/',
                        StringSplitOptions.RemoveEmptyEntries).TakeLast(1).FirstOrDefault(),
                    value => value.Value);
            ViewData["UserEmail"] = claimsDictionary?["emailaddress"];
            ViewData["UserNickName"] = claimsDictionary?["emailaddress"].TakeWhile(ch => ch != '@')
                .Aggregate("", (s, c) => s + c);
            ViewData["UserName"] = claimsDictionary?["givenname"];
            ViewData["UserSurname"] = claimsDictionary?["surname"];
            List<Poster> posters;
            Poster list;

            using (var db = new ApplicationContext())
            {
                var currentUser = db.Users.FirstOrDefault(us => us.Email == (string)ViewData["UserEmail"]);
                list = db.Posters.FirstOrDefault(pos => pos.PosterId == id);
                
                var eventFollower = new EventFollower()
                {
                    EventId = id,
                    FollowerId = currentUser.UserId,
                    Follower = currentUser,
                    Event =  list
                };

                currentUser.EventFollowers.Add(eventFollower);
                posters = currentUser.EventFollowers.Select(ef => ef.Event).ToList();
                db.SaveChanges(true);
             
            }

            return View("Index", posters);
        }
    }
}
