using System;
using Microsoft.AspNetCore.Mvc;
using Hackaton_test.Models;
using Hackaton_test.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace Hackaton_test.Controllers
{
    [Authorize]
    public class PosterCreationController : Controller
    {
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewPoster(Poster poster, User user)
        {
            string posterData = $"Title: {poster.Title}, Description: {poster.Description}," +
                $" EventDate: {poster.EventDate},  " +
                $"Sport Type: {poster.SportType}, " +
                $" AuthorId: {poster.AuthorId = user.UserId}";
               

            return Content(posterData);
        }
    }
}