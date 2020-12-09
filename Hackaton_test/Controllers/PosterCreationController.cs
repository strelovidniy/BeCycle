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
            Poster poster = new Poster();
            return View(poster);
        }
        [HttpPost]
        public IActionResult NewPoster(Poster poster, User user)
        {
            string posterData = $"Title: {poster.Title}, Description: {poster.Description}," +
                $" EventDate: {poster.EventDate}, Publication Date: {poster.PublicationDate = DateTime.Now}, " +
                $"Sport Type: {poster.SportType}, Author: {poster.Author = user}," +
                $" AuthorId: {poster.AuthorId = user.UserId}";
               

            return Content(posterData);
        }
    }
}