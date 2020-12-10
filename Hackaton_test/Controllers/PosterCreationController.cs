using System;
using Microsoft.AspNetCore.Mvc;
using Hackaton_test.Models;
using Hackaton_test.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

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
        public IActionResult Index(Poster poster)
        {
            string posterData = $"Title: {poster.Title}, Description: {poster.Description}," +
                                $" EventDate: {poster.EventDate},  " +
                                $"Sport Type: {poster.SportType}, " +
                                $"UserId: {poster.AuthorId = 1}, ";
            HttpContext.Session.GetInt32("UserId");
               

            return Content(posterData);
        }
    }
}