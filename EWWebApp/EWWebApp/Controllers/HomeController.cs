using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EWWebApp.Models;
using EWWebApp.Backend;

namespace EWWebApp.Controllers
{
    public class HomeController : Controller
    {
        private EWBackend myData = EWBackend.Instance;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        // Get 
        public IActionResult Encrypt()
        {
            return View(myData);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Encrypt(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                // Send back for Edit
                return View(myData);
            }
            return RedirectToAction("Result", "Home", new { word });
        }

        // POST
        public IActionResult Result(string word)
        {
            myData.Encrypt(word);
            return View(myData);
        }

        //GET
        public IActionResult GuessShift()
        {
            return View(myData);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuessShift(int guess)
        {
            myData.GuessShift(guess);
            return View(myData);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
