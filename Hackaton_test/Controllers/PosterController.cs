using Hackaton_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hackaton_test.Controllers
{
    public class PosterController:Controller
    {
        //TODO: add method that will be get poster by id
        public ActionResult Index()
        {
            return View();
        }

        // public IActionResult Index(int id)
        // {
        //    var poster = //DB.GetPosterByID(id);
        //     return View(poster);
        // }
    }
}