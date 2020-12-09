using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hackaton_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

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
            var claims = result.Principal?.Identities.FirstOrDefault().Claims.Select(claims => new { claims.Type, claims.Value });
            var dictionary = claims.ToDictionary(key =>
            {
                string[] splitStrings = key.Type.Split('/', StringSplitOptions.RemoveEmptyEntries);
                return splitStrings[^1];
            }, value => value.Value);
            await using (ApplicationContext dbContext = new ApplicationContext())
            {
                var dbUser = dbContext.Users.Where(user => user.Email == dictionary["emailaddress"]);
                string nickName = dictionary["emailaddress"].TakeWhile(ch => ch != '@').Aggregate("", (s, c) => s + c);
                if (dbUser.Count() == 0)
                {
                    dbContext.Users.Add(new User()
                    {
                        Email = dictionary["emailaddress"], FirstName = dictionary["givenname"],
                        LastName = dictionary["surname"], NickName = nickName
                    });
                }

                await dbContext.SaveChangesAsync(true);
            }

            return Redirect("~/Home");
        }
    }
}
