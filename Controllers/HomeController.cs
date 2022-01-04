using System;
using launchpadApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace launchpadApp.Controllers {

    public class HomeController : Controller {

        private Manager manager;

        public HomeController(Manager myManager) {
            manager = myManager;

        }

        public IActionResult Index() {
            return View(manager);            
        }

    }
}
