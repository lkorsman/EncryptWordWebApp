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
        EWBackend myData = new EWBackend();
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
        public ActionResult Encrypt([Bind(include:
                                    "Word,"+
                                    "Result,"+
                                    "")] EWBackend data)
        {
            if (data == null)
            {
                // Send to Error Page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Word))
            {
                // Send back for Edit
                return View(data);
            }

            return RedirectToAction("Result", "Home", data);
        }

        // POST
        public IActionResult Result(EWBackend data)
        {
            data.Encrypt(data.Word);
            return View(data);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
