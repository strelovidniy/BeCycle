using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

            using (var db = new ApplicationContext())
            {
                list = db.Posters.OrderByDescending(pos => pos.EventDate).ToList();
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
                posters = dbContext.Posters.Where(poster =>
                    dbContext.Users.FirstOrDefault(user => user.NickName == (ViewData["UserNickName"] as string))
                        .Posters.Contains(poster)).ToList();
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

            User currentUser;
            Poster currentPoster;

            using (var db = new ApplicationContext())
            {
                currentUser = db.Users.FirstOrDefault(us => us.Email == (string)ViewData["UserEmail"]);
                currentPoster = db.Posters.FirstOrDefault(pos => pos.PosterId == id);
            }

            var eventFollower = new EventFollower()
            {
                Event = currentPoster,
                Follower = currentUser,
                EventId = id,
                FollowerId = currentUser.UserId
            };

            currentUser.EventFollowers.Add(eventFollower);
            currentPoster.EventFollowers.Add(eventFollower);

            List<Poster> posters = new List<Poster>() { new Poster() { PosterId = 100, Title = "lol", Description = "Dec" } };

            // using (var dbContext = new ApplicationContext())
            // {
            //     posters = dbContext.Posters.Where(poster =>
            //         dbContext.Users.FirstOrDefault(user => user.NickName == (ViewData["UserNickname"] as string))
            //             .Posters.Contains(poster)).ToList();
            // }

            return View("Index", posters);





            return RedirectToAction("Following", "Home");
        }
    }

}
