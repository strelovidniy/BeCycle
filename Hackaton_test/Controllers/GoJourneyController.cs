using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class GoJourneyController : Controller
    {
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
    }
}
