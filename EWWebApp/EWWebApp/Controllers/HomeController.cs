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
        // Create instance of an EncryptWord object
        private EWBackend myData = EWBackend.Instance;

        // Landing page of the app
        public IActionResult Index()
        {
            return View();
        }

        // Placeholder, contains default About page
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        // Placeholder, contains default Contact page
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        // GET
        // Allows user to encrypt a word
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
            else if (word.Length <= 3)
            {
                return View();
            }
            return RedirectToAction("Result", "Home", new { word });
        }

        // POST
        // Shows result of Caesar cipher encryption
        public IActionResult Result(string word)
        {
            myData.Encrypt(word);
            return View(myData);
        }

        //GET 
        // allows user to guess Caesar shift value
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

        // Resets the EncryptWord (EWBackend object)
        public IActionResult Reset()
        {
            myData.Reset();
            return RedirectToAction("Encrypt", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
