using System;
using launchpadApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace launchpadApp.Controllers {

    public class HomeController : Controller {

        private LinkManager linkManager;
        private CategoryManager categoryManager;

        public HomeController(CategoryManager myManager) {
            categoryManager = myManager;

        }

        public IActionResult Index() {
            // if (HttpContext.Session.GetString("auth") != "true") {
            //     return RedirectToAction("Index","Login");
            // }
            return View(categoryManager);            
        }

    }
}
