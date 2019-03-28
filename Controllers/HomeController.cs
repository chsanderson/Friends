//Christopher Sanderson
//Friends
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Friends.Models;

namespace Friends.Controllers
{
    public class HomeController : Controller
    {
        //this returns the index view for the home directory 
        public IActionResult Index()
        {
            return View();
        }

        //this returns the about view and sets a view data message that is displayed wither in the header or in the body
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //this returns the contact view and sets a view data message that is displayed wither in the header or in the body
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        //this returns the privacy view
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
