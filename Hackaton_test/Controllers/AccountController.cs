using System;
using System.Linq;
using System.Threading.Tasks;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;

namespace Hackaton_test.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        [Route("google-signin")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal?.Identities.FirstOrDefault().Claims
                .Select(claims => new { claims.Type, claims.Value });
            var dictionary = claims.ToDictionary(key =>
            {
                var splitStrings = key.Type.Split('/', StringSplitOptions.RemoveEmptyEntries);
                return splitStrings[^1];
            }, value => value.Value);
            await using (var dbContext = new ApplicationContext())
            {
                var dbUser = await dbContext.Users.FindAsync(dictionary["emailaddress"]);
                    //.Where(user => user.Email == dictionary["emailaddress"]);
               
                if (dbUser == null)
                {
                    var nickName = dictionary["emailaddress"].TakeWhile(ch => ch != '@')
                        .Aggregate("", (s, c) => s + c);
                    var registeredUser = await dbContext.Users.AddAsync(new User()
                    {
                        Email = dictionary["emailaddress"], FirstName = dictionary["givenname"],
                        LastName = dictionary["surname"], NickName = nickName
                    });

                    HttpContext.Session.SetInt32("UserId", registeredUser.Entity.UserId);
                    await dbContext.SaveChangesAsync(true);
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", dbUser.UserId);
                }
            }

            ViewData["UserId"] = HttpContext.Session.Get("UserId");
            return Redirect("~/Home");
        }
    }
}
