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

            var googleAuthData = claims.ToDictionary(
                key =>
                {
                    var splitStrings = key.Type.Split('/', StringSplitOptions.RemoveEmptyEntries);
                    return splitStrings[^1];
                },
                value => value.Value);

            await using (var dbContext = new ApplicationContext())
            {
                var dbUsers = dbContext.Users.Where(user => user.Email == googleAuthData["emailaddress"]);
                    
                    var dbUser = dbUsers.FirstOrDefault();

                if (dbUser == null)
                {
                    var nickName = googleAuthData["emailaddress"].TakeWhile(ch => ch != '@')
                        .Aggregate("", (s, c) => s + c);

                    var registeredUser = await dbContext.Users.AddAsync(new User()
                    {
                        Email = googleAuthData["emailaddress"], FirstName = googleAuthData["givenname"],
                        LastName = googleAuthData["surname"], NickName = nickName
                    });

                    HttpContext.Session.SetInt32("UserId", registeredUser.Entity.UserId);
                    HttpContext.Session.SetString("UserName", registeredUser.Entity.FirstName);
                    HttpContext.Session.SetString("UserSurname", registeredUser.Entity.LastName);
                    HttpContext.Session.SetString("UserNickname", registeredUser.Entity.NickName);
                    HttpContext.Session.SetString("UserEmail", registeredUser.Entity.Email);

                    try
                    {
                        HttpContext.Session.SetString("UserPhone", registeredUser.Entity.PhoneNumber);
                    }
                    catch
                    {
                        // ignored
                    }

                    await dbContext.SaveChangesAsync(true);
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", dbUser.UserId);
                    HttpContext.Session.SetString("UserName", dbUser.FirstName);
                    HttpContext.Session.SetString("UserSurname", dbUser.LastName);
                    HttpContext.Session.SetString("UserEmail", dbUser.Email);
                    HttpContext.Session.SetString("UserNickname", dbUser.NickName);

                    try
                    {
                        HttpContext.Session.SetString("UserPhone", dbUser.PhoneNumber);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
