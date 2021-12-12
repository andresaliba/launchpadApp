using System;
using launchpadApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace launchpadApp.Controllers {

    public class HomeController : Controller {

        private LinkManager linkManager;
        private CategoryManager categoryManager;

        public HomeController(CategoryManager myManager) {
            categoryManager = myManager;

        }

        public IActionResult Index() {
            return View(categoryManager);            
        }

    }
}
